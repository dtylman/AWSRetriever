using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.Runtime;

namespace CloudOps.APIGateway
{
    public class GetDomainNamesOperation : Operation
    {
        public override string Name => "GetDomainNames";

        public override string Description => "Represents a collection of DomainName resources.";
 
        public override string RequestURI => "/domainnames";

        public override string Method => "GET";

        public override string ServiceName => "APIGateway";

        public override string ServiceID => "API Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAPIGatewayConfig config = new AmazonAPIGatewayConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonAPIGatewayClient client = new AmazonAPIGatewayClient(creds, config);
            
            GetDomainNamesResponse resp = new GetDomainNamesResponse();
            do
            {
                GetDomainNamesRequest req = new GetDomainNamesRequest
                {
                    Position = resp.Position
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.GetDomainNames(req);
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