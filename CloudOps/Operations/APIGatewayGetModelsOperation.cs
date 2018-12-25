using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class APIGatewayGetModelsOperation : Operation
    {
        public override string Name => "GetModels";

        public override string Description => "Describes existing Models defined for a RestApi resource.";
 
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
                GetModelsRequest req = new GetModelsRequest
                {
                    Position = resp.Position
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.GetModels(req);
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