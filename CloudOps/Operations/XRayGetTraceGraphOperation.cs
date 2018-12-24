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
 
        public override string RequestURI => "/TraceGraph";

        public override string Method => "POST";

        public override string ServiceName => "XRay";

        public override string ServiceID => "XRay";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonXRayClient client = new AmazonXRayClient(creds, region);
            GetTraceGraphResult resp = new GetTraceGraphResult();
            do
            {
                GetTraceGraphRequest req = new GetTraceGraphRequest
                {
                    NextToken = resp.NextToken,
                    &lt;nil&gt; = maxItems
                };
                resp = client.GetTraceGraph(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Services)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}