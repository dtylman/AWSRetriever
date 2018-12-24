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
 
        public override string RequestURI => "/usageplans/{usageplanId}/keys";

        public override string Method => "GET";

        public override string ServiceName => "APIGateway";

        public override string ServiceID => "API Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAPIGatewayClient client = new AmazonAPIGatewayClient(creds, region);
            UsagePlanKeys resp = new UsagePlanKeys();
            do
            {
                GetUsagePlanKeysRequest req = new GetUsagePlanKeysRequest
                {
                    position = resp.position,
                    limit = maxItems
                };
                resp = client.GetUsagePlanKeys(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.items)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.position));
        }
    }
}