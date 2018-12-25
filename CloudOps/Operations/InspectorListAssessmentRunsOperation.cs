using Amazon;
using Amazon.Inspector;
using Amazon.Inspector.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class InspectorListAssessmentRunsOperation : Operation
    {
        public override string Name => "ListAssessmentRuns";

        public override string Description => "Lists the assessment runs that correspond to the assessment templates that are specified by the ARNs of the assessment templates.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Inspector";

        public override string ServiceID => "Inspector";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonInspectorClient client = new AmazonInspectorClient(creds, region);
            ListAssessmentRunsResponse resp = new ListAssessmentRunsResponse();
            do
            {
                ListAssessmentRunsRequest req = new ListAssessmentRunsRequest
                {
                    nextToken = resp.nextToken
                    ,
                    maxResults = maxItems
                                        
                };

                resp = client.ListAssessmentRuns(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.assessmentRunArns)
                {
                    AddObject(obj);
                }
                
                foreach (var obj in resp.nextToken)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}