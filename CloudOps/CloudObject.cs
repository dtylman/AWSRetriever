using System;
using Amazon;
using Newtonsoft.Json;

namespace CloudOps
{
    public class CloudObject
    {
        private string service;
        private string typeName;
        private string typeFullName;
        private string operation;
        private string region;
        private string source;

        public string Service { get => service; set => service = value; }
        public string TypeName { get => typeName; set => typeName = value; }
        public string TypeFullName { get => typeFullName; set => typeFullName = value; }
        public string Operation { get => operation; set => operation = value; }
        public string Region { get => region; set => region = value; }
        public string Source { get => source; set => source = value; }

        public CloudObject()
        {

        }

        public CloudObject(string operation, string region, string service, string typeName, string typeFullName, object source)
        {
            this.operation = operation;
            this.region = region;
            this.service = service;
            this.typeName = typeName;
            this.typeFullName = typeFullName;
            this.source = JsonConvert.SerializeObject(source, Formatting.Indented);
        }       

        public override string ToString()
        {
            return string.Format("{0} {1} {2} ", this.Region, this.Service, this.typeName);
        }

    }
}