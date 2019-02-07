using System;
using System.Collections.Concurrent;
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
        private AWSCredentials creds;
        private int maxItems;
        private WebProxy proxy;

        public CancellationToken CancellationToken { get; internal set; }                
        public ConcurrentBag<CloudObject> CollectedObjects => collectedObjects;        
        public WebProxy Proxy { get => proxy; set => proxy = value; }
        public RegionEndpoint Region { get => region; set => region = value; }
       
        public int MaxItems { get => maxItems; set => maxItems = value; }
        public AWSCredentials Creds { get => creds; set => creds = value; }

        private readonly ConcurrentBag<CloudObject> collectedObjects = new ConcurrentBag<CloudObject>();


        protected virtual void CheckError(HttpStatusCode httpStatusCode, string code)
        {
            if (this.CancellationToken != null)
            {
                this.CancellationToken.ThrowIfCancellationRequested();
            }

            if (Int32.TryParse(code, out int res))
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

        protected virtual void ConfigureClient(ClientConfig config)
        {
            if (this.Proxy != null)
            {
                config.SetWebProxy(Proxy);
            }
        }

        public OperationResult Invoke(CancellationToken token)
        {            
            try
            {
                this.CancellationToken = token;
                this.Invoke(this.creds, this.region, this.maxItems);
                return new OperationResult(this);
            }
            catch (Exception ex)
            {
                return new OperationResult(ex, this);
            }
        }

        /// <summary>
        /// deep copies the operaiton overriding the provided fields.
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="creds"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Operation Clone(WebProxy proxy, RegionEndpoint region, AWSCredentials creds, int pageSize)
        {
            Operation op = (Operation)Activator.CreateInstance(GetType());
            op.Region = region;
            op.proxy = proxy;
            op.creds = creds;
            op.maxItems = pageSize;
            return op;
        }
    }
}
