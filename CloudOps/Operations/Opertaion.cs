using System;
using Amazon;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public abstract class Operation
    {

        public virtual bool SupportsRegion(RegionEndpoint region)
        {
            return true; //override when needed
        }

        public abstract void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems);
    //    public abstract string Name;
    //    public abstract string Description;

    }
}
