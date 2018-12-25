using Amazon;
using Amazon.Inspector;
using Amazon.Inspector.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class InspectorListAssessmentTemplatesOperation : Operation
    {
        public override string Name => "ListAssessmentTemplates";

        public override string Description => "Lists the assessment templates that correspond to the assessment targets that are specified by the ARNs of the assessment targets.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Inspector";

        public override string ServiceID => "Inspector";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonInspectorClient client = new AmazonInspectorClient(creds, region);
            ListAssessmentTemplatesResponse resp = new ListAssessmentTemplatesResponse();
            do
            {
                ListAssessmentTemplatesRequest req = new ListAssessmentTemplatesRequest
                {
                    nextToken = resp.nextToken
                    ,
                    maxResults = maxItems
                                        
                };

                resp = client.ListAssessmentTemplates(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.assessmentTemplateArns)
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