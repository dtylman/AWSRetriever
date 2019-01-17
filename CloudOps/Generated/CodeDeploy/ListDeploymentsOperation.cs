using Amazon;
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;
using Amazon.Runtime;

namespace CloudOps.CodeDeploy
{
    public class ListDeploymentsOperation : Operation
    {
        public override string Name => "ListDeployments";

        public override string Description => "Lists the deployments in a deployment group for an application registered with the applicable IAM user or AWS account.";
 
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
            
            ListDeploymentsResponse resp = new ListDeploymentsResponse();
            do
            {
                ListDeploymentsRequest req = new ListDeploymentsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListDeployments(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Deployments)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}