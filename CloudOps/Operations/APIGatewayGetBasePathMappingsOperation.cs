using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class APIGatewayGetBasePathMappingsOperation : Operation
    {
        public override string Name => "GetBasePathMappings";

        public override string Description => "Represents a collection of BasePathMapping resources.";
 
        public override string RequestURI => "/domainnames/{domain_name}/basepathmappings";

        public override string Method => "GET";

        public override string ServiceName => "APIGateway";

        public override string ServiceID => "API Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAPIGatewayClient client = new AmazonAPIGatewayClient(creds, region);
            BasePathMappings resp = new BasePathMappings();
            do
            {
                GetBasePathMappingsRequest req = new GetBasePathMappingsRequest
                {
                    position = resp.position,
                    limit = maxItems
                };
                resp = client.GetBasePathMappings(req);
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