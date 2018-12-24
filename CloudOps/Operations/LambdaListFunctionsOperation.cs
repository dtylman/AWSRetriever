using Amazon;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class LambdaListFunctionsOperation : Operation
    {
        public override string Name => "ListFunctions";

        public override string Description => "Returns a list of your Lambda functions. For each function, the response includes the function configuration information. You must use GetFunction to retrieve the code for your function. This operation requires permission for the lambda:ListFunctions action. If you are using the versioning feature, you can list all of your functions or only $LATEST versions. For information about the versioning feature, see AWS Lambda Function Versioning and Aliases. ";
 
        public override string RequestURI => "/2015-03-31/functions/";

        public override string Method => "GET";

        public override string ServiceName => "Lambda";

        public override string ServiceID => "Lambda";

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
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.Functions)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));
        }
    }
}