using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
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
        private RegionEndpoint region;
        public CancellationToken CancellationToken { get; internal set; }        

        public List<CloudObject> CollectedObjects => collectedObjects;

        public RegionEndpoint Region { get => region; set => region = value; }

        private readonly List<CloudObject> collectedObjects = new List<CloudObject>();


        protected virtual void CheckError(HttpStatusCode httpStatusCode, string code)
        {
            if (this.CancellationToken != null)
            {
                this.CancellationToken.ThrowIfCancellationRequested();
            }

            int res;
            if (Int32.TryParse(code, out res))
            {
                if ((int)httpStatusCode == res)
                {
                    return;
                }
            }
            if (httpStatusCode.ToString() == code)
            {
                return;                
            }
            throw new ApplicationException(string.Format("Failed to execute '{0}', HttpStatus: {1}", Name, code));
        }

        protected virtual void AddObject(Object obj)
        {
            Type t = obj.GetType();
            collectedObjects.Add(new CloudObject(Name,region: Region.SystemName, service: ServiceName,
                typeName: t.Name, typeFullName: t.AssemblyQualifiedName, source: obj));
        }
    }
}
