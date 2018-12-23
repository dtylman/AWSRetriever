using System;
using System.Collections.Generic;
using Amazon;
using Amazon.Runtime;
using CloudOps.Operations;

namespace CloudOps
{
    public class Scanner
    {
        private readonly List<Operation> operations;
        private readonly AWSCredentials creds;
        private readonly int maxItems = 100;

        public Scanner()
        {
            this.operations = new List<Operation>
            {
                new LambaListFunctionsOperation()
            };
        }

        void Scan()
        {
            List<RegionEndpoint> regions = new List<RegionEndpoint>(RegionEndpoint.EnumerableAllRegions);
            foreach (Operation op in this.operations)
            {
                foreach (RegionEndpoint region in regions)
                {
                    if (op.SupportsRegion(region))
                    {
                        op.Invoke(this.creds, region, this.maxItems);
                    }
                }
            }
        }
    }
}
