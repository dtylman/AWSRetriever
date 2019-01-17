using Amazon;
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;
using Amazon.Runtime;

namespace CloudOps.CodeDeploy
{
    public class ListDeploymentGroupsOperation : Operation
    {
        public override string Name => "ListDeploymentGroups";

        public override string Description => "Lists the deployment groups for an application registered with the applicable IAM user or AWS account.";
 
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
            
            ListDeploymentGroupsResponse resp = new ListDeploymentGroupsResponse();
            do
            {
                ListDeploymentGroupsRequest req = new ListDeploymentGroupsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListDeploymentGroups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DeploymentGroups)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}