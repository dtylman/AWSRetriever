using System;
using System.Collections.Generic;
using System.ComponentModel;
using Amazon;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Amazon.Runtime;

namespace heaven.APIs
{
    public class Lambda : AWSService
    {
        public Lambda(List<AWSObject> container, int maxItems) : base(container, maxItems)
        {
        }

        public override string Name
        {
            get
            {
                return "Lambda";
            }
        }

        public override void Scan(AWSCredentials credentials, RegionEndpoint region, BackgroundWorker worker, int currentProgress)
        {
            AmazonLambdaClient client = new AmazonLambdaClient(credentials, region);
            ListFunctionsResponse resp = new ListFunctionsResponse();                      
            do
            {
                ListFunctionsRequest req = new ListFunctionsRequest
                {
                    Marker = resp.NextMarker,
                    MaxItems = this.maxItems
                };
                resp = client.ListFunctions(req);
                CheckError(resp.HttpStatusCode, resp);

                foreach (FunctionConfiguration func in resp.Functions)
                {
                    AWSObject awsObject = new AWSObject
                    {
                        Name = func.FunctionName,
                        Region = region.SystemName,
                        Arn = func.FunctionArn,
                        Description = func.Description,
                        LastModified = func.LastModified,
                        Version = func.Version,
                        Role = func.Role
                    };
                    AddObject(awsObject,func);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));

        }

    }
}
