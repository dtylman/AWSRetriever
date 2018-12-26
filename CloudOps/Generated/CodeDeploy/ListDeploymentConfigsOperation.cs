using Amazon;
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;
using Amazon.Runtime;

namespace CloudOps.CodeDeploy
{
    public class ListDeploymentConfigsOperation : Operation
    {
        public override string Name => "ListDeploymentConfigs";

        public override string Description => "Lists the deployment configurations with the applicable IAM user or AWS account.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CodeDeploy";

        public override string ServiceID => "CodeDeploy";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCodeDeployClient client = new AmazonCodeDeployClient(creds, region);
            ListDeploymentConfigsResponse resp = new ListDeploymentConfigsResponse();
            do
            {
                ListDeploymentConfigsRequest req = new ListDeploymentConfigsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListDeploymentConfigs(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DeploymentConfigsList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}