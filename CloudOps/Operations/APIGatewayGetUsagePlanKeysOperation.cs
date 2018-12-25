using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class APIGatewayGetUsagePlanKeysOperation : Operation
    {
        public override string Name => "GetUsagePlanKeys";

        public override string Description => "Gets all the usage plan keys representing the API keys added to a specified usage plan.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "APIGateway";

        public override string ServiceID => "API Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAPIGatewayClient client = new AmazonAPIGatewayClient(creds, region);
            Response resp = new Response();
            do
            {
                GetUsagePlanKeysRequest req = new GetUsagePlanKeysRequest
                {
                    Position = resp.Position
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.GetUsagePlanKeys(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Items)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Position));
        }
    }
}