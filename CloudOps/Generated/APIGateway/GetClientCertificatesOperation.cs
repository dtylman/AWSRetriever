using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.Runtime;

namespace CloudOps.APIGateway
{
    public class GetClientCertificatesOperation : Operation
    {
        public override string Name => "GetClientCertificates";

        public override string Description => "Gets a collection of ClientCertificate resources.";
 
        public override string RequestURI => "/clientcertificates";

        public override string Method => "GET";

        public override string ServiceName => "APIGateway";

        public override string ServiceID => "API Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAPIGatewayConfig config = new AmazonAPIGatewayConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonAPIGatewayClient client = new AmazonAPIGatewayClient(creds, config);
            
            GetClientCertificatesResponse resp = new GetClientCertificatesResponse();
            do
            {
                GetClientCertificatesRequest req = new GetClientCertificatesRequest
                {
                    Position = resp.Position
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.GetClientCertificates(req);
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