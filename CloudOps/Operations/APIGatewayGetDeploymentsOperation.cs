using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class APIGatewayGetDeploymentsOperation : Operation
    {
        public override string Name => "GetDeployments";

        public override string Description => "Gets information about a Deployments collection.";
 
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
                GetDeploymentsRequest req = new GetDeploymentsRequest
                {
                    Position = resp.Position
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.GetDeployments(req);
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