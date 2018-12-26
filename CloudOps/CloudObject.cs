using Amazon;

namespace CloudOps
{
    public class CloudObject
    {
        private readonly string service;
        private readonly object source;
        private readonly string objectType;
        private readonly RegionEndpoint region;

        public CloudObject(RegionEndpoint region, string service, object source)
        {
            this.region = region;
            this.service = service;            
            this.source = source;
            System.Type t = this.source.GetType();
            this.objectType = t.Name;
        }

        public string Service => service;

        public object Source => source;

        public string ObjectType => objectType;

        public RegionEndpoint Region => region;

        public override string ToString()
        {
            return string.Format("{0} {1} {2} ", this.Region, this.Service, this.ObjectType);
        }
    }
}