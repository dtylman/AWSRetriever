using Amazon;
using Amazon.XRay;
using Amazon.XRay.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class XRayGetTraceGraphOperation : Operation
    {
        public override string Name => "GetTraceGraph";

        public override string Description => "Retrieves a service graph for one or more specific trace IDs.";
 
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
                GetTraceGraphRequest req = new GetTraceGraphRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.GetTraceGraph(req);
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