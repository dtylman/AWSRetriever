using Amazon;
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;
using Amazon.Runtime;

namespace CloudOps.CodeDeploy
{
    public class ListApplicationRevisionsOperation : Operation
    {
        public override string Name => "ListApplicationRevisions";

        public override string Description => "Lists information about revisions for an application.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CodeDeploy";

        public override string ServiceID => "CodeDeploy";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCodeDeployConfig config = new AmazonCodeDeployConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonCodeDeployClient client = new AmazonCodeDeployClient(creds, config);
            
            ListApplicationRevisionsResponse resp = new ListApplicationRevisionsResponse();
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