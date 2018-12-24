using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class APIGatewayGetResourcesOperation : Operation
    {
        public override string Name => "GetResources";

        public override string Description => "Lists information about a collection of Resource resources.";
 
        public override string RequestURI => "/restapis/{restapi_id}/resources";

        public override string Method => "GET";

        public override string ServiceName => "APIGateway";

        public override string ServiceID => "API Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAPIGatewayClient client = new AmazonAPIGatewayClient(creds, region);
            Resources resp = new Resources();
            do
            {
                GetResourcesRequest req = new GetResourcesRequest
                {
                    position = resp.position,
                    limit = maxItems
                };
                resp = client.GetResources(req);
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