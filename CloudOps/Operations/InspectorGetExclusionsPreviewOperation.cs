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
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "Inspector";

        public override string ServiceID => "Inspector";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonInspectorClient client = new AmazonInspectorClient(creds, region);
            Response resp = new Response();
            do
            {
                GetExclusionsPreviewRequest req = new GetExclusionsPreviewRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetExclusionsPreview(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}