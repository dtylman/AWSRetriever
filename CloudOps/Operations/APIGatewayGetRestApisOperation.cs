using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class APIGatewayGetRestApisOperation : Operation
    {
        public override string Name => "GetRestApis";

        public override string Description => "Lists the RestApis resources for your collection.";
 
        public override string RequestURI => "/restapis";

        public override string Method => "GET";

        public override string ServiceName => "APIGateway";

        public override string ServiceID => "API Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAPIGatewayClient client = new AmazonAPIGatewayClient(creds, region);
            RestApis resp = new RestApis();
            do
            {
                GetRestApisRequest req = new GetRestApisRequest
                {
                    position = resp.position
                    ,
                    limit = maxItems
                                        
                };

                resp = client.GetRestApis(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.items)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.position));
        }
    }
}