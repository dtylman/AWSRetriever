using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using Amazon;
using Amazon.Runtime;

namespace heaven.APIs
{
    public abstract class AWSService
    {
        protected readonly List<AWSObject> list;
        protected int maxItems;

        protected AWSService(List<AWSObject> list, int maxItems)
        {
            this.list = list;
            this.maxItems = maxItems;
        }

        public abstract string Name { get; }

        public abstract void Scan(AWSCredentials credentials, RegionEndpoint region, BackgroundWorker worker, int currentProgress);

        protected void AddObject(AWSObject awsObject, object innerObject)
        {
            awsObject.Service = Name;
            awsObject.Type = innerObject.GetType().Name;
            awsObject.Object = innerObject;
            this.list.Add(awsObject);
        }

        protected virtual void CheckError(HttpStatusCode httpStatusCode, object exceptionMessage)
        {
            if (httpStatusCode != HttpStatusCode.OK)
            {
                throw new ApplicationException(exceptionMessage.ToString());
            }
        }
    }
}