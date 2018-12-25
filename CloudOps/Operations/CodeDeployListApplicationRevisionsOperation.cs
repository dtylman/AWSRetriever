using Amazon;
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CodeDeployListApplicationRevisionsOperation : Operation
    {
        public override string Name => "ListApplicationRevisions";

        public override string Description => "Lists information about revisions for an application.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "CodeDeploy";

        public override string ServiceID => "CodeDeploy";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCodeDeployClient client = new AmazonCodeDeployClient(creds, region);
            Response resp = new Response();
            do
            {
                ListApplicationRevisionsRequest req = new ListApplicationRevisionsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListApplicationRevisions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Revisions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}