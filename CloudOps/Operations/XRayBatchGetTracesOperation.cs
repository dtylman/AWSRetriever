using Amazon;
using Amazon.XRay;
using Amazon.XRay.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class XRayBatchGetTracesOperation : Operation
    {
        public override string Name => "BatchGetTraces";

        public override string Description => "Retrieves a list of traces specified by ID. Each trace is a collection of segment documents that originates from a single request. Use GetTraceSummaries to get a list of trace IDs.";
 
        public override string RequestURI => "/Traces";

        public override string Method => "POST";

        public override string ServiceName => "XRay";

        public override string ServiceID => "XRay";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonXRayClient client = new AmazonXRayClient(creds, region);
            BatchGetTracesResult resp = new BatchGetTracesResult();
            do
            {
                BatchGetTracesRequest req = new BatchGetTracesRequest
                {
                    NextToken = resp.NextToken,
                    &lt;nil&gt; = maxItems
                };
                resp = client.BatchGetTraces(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Traces)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}