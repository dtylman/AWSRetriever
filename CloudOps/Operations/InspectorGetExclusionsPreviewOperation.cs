using Amazon;
using Amazon.Inspector;
using Amazon.Inspector.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class InspectorGetExclusionsPreviewOperation : Operation
    {
        public override string Name => "GetExclusionsPreview";

        public override string Description => "Retrieves the exclusions preview (a list of ExclusionPreview objects) specified by the preview token. You can obtain the preview token by running the CreateExclusionsPreview API.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Inspector";

        public override string ServiceID => "Inspector";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonInspectorClient client = new AmazonInspectorClient(creds, region);
            GetExclusionsPreviewResponse resp = new GetExclusionsPreviewResponse();
            do
            {
                GetExclusionsPreviewRequest req = new GetExclusionsPreviewRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.GetExclusionsPreview(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}