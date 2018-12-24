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
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CodeDeploy";

        public override string ServiceID => "CodeDeploy";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCodeDeployClient client = new AmazonCodeDeployClient(creds, region);
            ListApplicationRevisionsOutput resp = new ListApplicationRevisionsOutput();
            do
            {
                ListApplicationRevisionsInput req = new ListApplicationRevisionsInput
                {
                    nextToken = resp.nextToken,
                    &lt;nil&gt; = maxItems
                };
                resp = client.ListApplicationRevisions(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.revisions)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}