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
                GetBasePathMappingsRequest req = new GetBasePathMappingsRequest
                {
                    Position = resp.Position
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.GetBasePathMappings(req);
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