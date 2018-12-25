using Amazon;
using Amazon.Inspector;
using Amazon.Inspector.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class InspectorListAssessmentRunAgentsOperation : Operation
    {
        public override string Name => "ListAssessmentRunAgents";

        public override string Description => "Lists the agents of the assessment runs that are specified by the ARNs of the assessment runs.";
 
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
                ListAssessmentRunAgentsRequest req = new ListAssessmentRunAgentsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListAssessmentRunAgents(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}