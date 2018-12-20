using System.Collections.Generic;
using Amazon;
using Amazon.Runtime;

namespace heaven.APIs
{
    public abstract class AWSAPI
    {
        private readonly List<AWSObject> container;
        protected int maxItems;

        protected AWSAPI(List<AWSObject> container, int maxItems)
        {
            this.container = container;
            this.maxItems = maxItems;
        }

        public abstract string Name { get; }

        public abstract void Read(AWSCredentials credentials, RegionEndpoint region);

        protected void AddObject(AWSObject awsObject)
        {
            awsObject.Type = Name;
            this.container.Add(awsObject);
        }
    }
}