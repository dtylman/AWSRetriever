using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class APIGatewayGetApiKeysOperation : Operation
    {
        public override string Name => "GetApiKeys";

        public override string Description => "Gets information about the current ApiKeys resource.";
 
        public override string RequestURI => "/apikeys";

        public override string Method => "GET";

        public override string ServiceName => "APIGateway";

        public override string ServiceID => "API Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAPIGatewayClient client = new AmazonAPIGatewayClient(creds, region);
            ApiKeys resp = new ApiKeys();
            do
            {
                GetApiKeysRequest req = new GetApiKeysRequest
                {
                    position = resp.position,
                    limit = maxItems
                };
                resp = client.GetApiKeys(req);
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