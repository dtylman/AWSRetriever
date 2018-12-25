using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class APIGatewayGetClientCertificatesOperation : Operation
    {
        public override string Name => "GetClientCertificates";

        public override string Description => "Gets a collection of ClientCertificate resources.";
 
        public override string RequestURI => "/clientcertificates";

        public override string Method => "GET";

        public override string ServiceName => "APIGateway";

        public override string ServiceID => "API Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAPIGatewayClient client = new AmazonAPIGatewayClient(creds, region);
            ClientCertificatesResponse resp = new ClientCertificatesResponse();
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