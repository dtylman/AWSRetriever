using System.Collections.Generic;
using Amazon;
using Amazon.Runtime;

namespace heaven.APIs
{
    public abstract class AWSAPI
    {
        protected readonly List<AWSObject> list;
        protected int maxItems;

        protected AWSAPI(List<AWSObject> list, int maxItems)
        {
            this.list = list;
            this.maxItems = maxItems;
        }

        public abstract string Name { get; }

        public abstract void Read(AWSCredentials credentials, RegionEndpoint region);

        protected void AddObject(AWSObject awsObject)
        {
            awsObject.Type = Name;
            this.list.Add(awsObject);
        }                
    }
}