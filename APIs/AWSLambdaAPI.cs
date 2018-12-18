using System;
using System.Collections.Generic;
using Amazon;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Amazon.Runtime;
using heaven.APIs;

namespace heaven.APIs
{
    public class AWSLambdaAPI : AWSAPI
    {
        public AWSLambdaAPI(List<AWSObject> container, int maxItems) : base(container, maxItems)
        {
        }

        public override string Name
        {
            get
            {
                return "Lambda: ListFunctions";
            }
        }

        public override void Read(AWSCredentials credentials, RegionEndpoint region)
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
                if (resp.HttpStatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new ApplicationException(resp.ToString());
                }
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
                        Role = func.Role,
                        Object = func,
                    };
                    AddObject(awsObject);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));
        }

    }
}
