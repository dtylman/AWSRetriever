using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class APIGatewayGetVpcLinksOperation : Operation
    {
        public override string Name => "GetVpcLinks";

        public override string Description => "Gets the VpcLinks collection under the caller&#39;s account in a selected region.";
 
        public override string RequestURI => "/vpclinks";

        public override string Method => "GET";

        public override string ServiceName => "APIGateway";

        public override string ServiceID => "API Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAPIGatewayClient client = new AmazonAPIGatewayClient(creds, region);
            VpcLinksResponse resp = new VpcLinksResponse();
            do
            {
                GetVpcLinksRequest req = new GetVpcLinksRequest
                {
                    Position = resp.Position
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.GetVpcLinks(req);
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