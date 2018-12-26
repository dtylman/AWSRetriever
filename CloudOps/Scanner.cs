using System;
using System.Collections.Generic;
using Amazon;
using Amazon.Runtime;

namespace CloudOps
{
    public class Scanner
    {        
        public Scanner()
        {
            
        }

        void Scan(AWSCredentials creds,int maxItems =100)
        {
            List<RegionEndpoint> regions = new List<RegionEndpoint>(RegionEndpoint.EnumerableAllRegions);
            foreach (Operation op in OperationFactory.All())
            {
                foreach (RegionEndpoint region in regions)
                {
                    if (op.SupportsRegion(region))
                    {
                        try
                        {
                            op.Invoke(creds, region, maxItems);
                        } catch(Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
            }
        }
    }
}
