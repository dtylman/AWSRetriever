using System.Collections.Generic;
using Amazon;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class LambaListFunctionsOperation : Operation
    {
        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonLambdaClient client = new AmazonLambdaClient(creds, region);
            ListFunctionsResponse resp = new ListFunctionsResponse();
            do
            {
                ListFunctionsRequest req = new ListFunctionsRequest
                {
                    Marker = resp.NextMarker,
                    MaxItems = maxItems
                };
                resp = client.ListFunctions(req);
                //CheckError(resp.HttpStatusCode, resp);

                foreach (FunctionConfiguration func in resp.Functions)
                {
                  
                }
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));

        }
    }
}