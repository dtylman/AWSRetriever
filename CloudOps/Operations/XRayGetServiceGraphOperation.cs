using Amazon;
using Amazon.XRay;
using Amazon.XRay.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class XRayGetServiceGraphOperation : Operation
    {
        public override string Name => "GetServiceGraph";

        public override string Description => "Retrieves a document that describes services that process incoming requests, and downstream services that they call as a result. Root services process incoming requests and make calls to downstream services. Root services are applications that use the AWS X-Ray SDK. Downstream services can be other applications, AWS resources, HTTP web APIs, or SQL databases.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "XRay";

        public override string ServiceID => "XRay";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonXRayClient client = new AmazonXRayClient(creds, region);
            Response resp = new Response();
            do
            {
                GetServiceGraphRequest req = new GetServiceGraphRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.GetServiceGraph(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Services)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}