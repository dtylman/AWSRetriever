using System;
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
        private CloudObjectFields names;
        private CloudObjectFields ids;
        private CloudObjectFields arns;

        public string Service { get => service; set => service = value; }
        public string TypeName { get => typeName; set => typeName = value; }
        public string TypeFullName { get => typeFullName; set => typeFullName = value; }
        public string Operation { get => operation; set => operation = value; }
        public string Region { get => region; set => region = value; }
        public string Source { get => source; set => source = value; }
        public CloudObjectFields Names { get => names; set => names = value; }
        public CloudObjectFields Ids { get => ids; set => ids = value; }
        public CloudObjectFields Arns { get => arns; set => arns = value; }

        public string Name
        {
            get
            {
                if (this.names != null)
                {
                    return this.names.FirstValue;
                }
                return "";
            }            
        }

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
            Type st = source.GetType();
            this.names = new CloudObjectFields(st, source, "Name");
            this.ids = new CloudObjectFields(st, source, "Id");
            this.arns = new CloudObjectFields(st, source, "Arn");
        }
        
        public override string ToString()
        {            
            return string.Format("{0} {1} {2} {3}", this.Region, this.Service, this.typeName, Name);
        }

        public override bool Equals(object obj)
        {            
            return source.Equals(obj);
        }

        public override int GetHashCode()
        {
            return source.GetHashCode();
        }
    }
}