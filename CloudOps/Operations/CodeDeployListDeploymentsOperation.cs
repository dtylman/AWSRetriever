using Amazon;
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CodeDeployListDeploymentsOperation : Operation
    {
        public override string Name => "ListDeployments";

        public override string Description => "Lists the deployments in a deployment group for an application registered with the applicable IAM user or AWS account.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CodeDeploy";

        public override string ServiceID => "CodeDeploy";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCodeDeployClient client = new AmazonCodeDeployClient(creds, region);
            ListDeploymentsOutput resp = new ListDeploymentsOutput();
            do
            {
                ListDeploymentsInput req = new ListDeploymentsInput
                {
                    nextToken = resp.nextToken,
                    &lt;nil&gt; = maxItems
                };
                resp = client.ListDeployments(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.deployments)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}