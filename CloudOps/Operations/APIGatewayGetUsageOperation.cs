using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class APIGatewayGetUsageOperation : Operation
    {
        public override string Name => "GetUsage";

        public override string Description => "Gets the usage data of a usage plan in a specified time interval.";
 
        public override string RequestURI => "/usageplans/{usageplanId}/usage";

        public override string Method => "GET";

        public override string ServiceName => "APIGateway";

        public override string ServiceID => "API Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAPIGatewayClient client = new AmazonAPIGatewayClient(creds, region);
            Usage resp = new Usage();
            do
            {
                GetUsageRequest req = new GetUsageRequest
                {
                    position = resp.position,
                    limit = maxItems
                };
                resp = client.GetUsage(req);
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