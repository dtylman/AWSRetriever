using Amazon;

namespace CloudOps
{    
    public class CloudObject
    {
        private readonly string service;
        private readonly string typeName;
        private readonly string typeFullName;
        private readonly object source;
        private readonly string region;

        public CloudObject(string region, string service, string typeName, string typeFullName, object source)
        {
            this.region = region;
            this.service = service;                        
            this.typeName = typeName;
            this.typeFullName = typeFullName;
            this.source = source;
        }

        public string Service => service;

        public object Source => source;        
        
        public string Region => region;

        public string TypeName => typeName;

        public string TypeFullName => typeFullName;

        public override string ToString()
        {
            return string.Format("{0} {1} {2} ", this.Region, this.Service, this.typeName);
        }
    }
}