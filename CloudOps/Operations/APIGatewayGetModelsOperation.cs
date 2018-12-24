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
 
        public override string RequestURI => "/restapis/{restapi_id}/models";

        public override string Method => "GET";

        public override string ServiceName => "APIGateway";

        public override string ServiceID => "API Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAPIGatewayClient client = new AmazonAPIGatewayClient(creds, region);
            Models resp = new Models();
            do
            {
                GetModelsRequest req = new GetModelsRequest
                {
                    position = resp.position,
                    limit = maxItems
                };
                resp = client.GetModels(req);
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