using Amazon;
using Amazon.Inspector;
using Amazon.Inspector.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class InspectorPreviewAgentsOperation : Operation
    {
        public override string Name => "PreviewAgents";

        public override string Description => "Previews the agents installed on the EC2 instances that are part of the specified assessment target.";
 
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
                PreviewAgentsRequest req = new PreviewAgentsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.PreviewAgents(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}