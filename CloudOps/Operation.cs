using System;
using System.Net;
using Amazon;
using Amazon.Runtime;

namespace CloudOps
{
    public abstract class Operation
    {
        public abstract void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems);
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract string RequestURI { get; }
        public abstract string Method { get; }
        public abstract string ServiceName { get; }
        public abstract string ServiceID { get; }

        public virtual bool SupportsRegion(RegionEndpoint region)
        {
            return true; //override when needed
        }

        protected virtual void CheckError(HttpStatusCode httpStatusCode, string code)
        {
            if (httpStatusCode.ToString() != code)
            {
                throw new ApplicationException(string.Format("Failed to execute '{0}', HttpStatus: {1}", Name, code));
            }
        }

        protected virtual void AddObject(Object obj)
        {
                         
        }
    }
}
