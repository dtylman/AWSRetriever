using Amazon;
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;
using Amazon.Runtime;

namespace CloudOps.CodeDeploy
{
    public class ListDeploymentInstancesOperation : Operation
    {
        public override string Name => "ListDeploymentInstances";

        public override string Description => "  The newer BatchGetDeploymentTargets should be used instead because it works with all compute types. ListDeploymentInstances throws an exception if it is used with a compute platform other than EC2/On-premises or AWS Lambda.    Lists the instance for a deployment associated with the applicable IAM user or AWS account. ";
 
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
            
            ListDeploymentInstancesResponse resp = new ListDeploymentInstancesResponse();
            do
            {
                ListDeploymentInstancesRequest req = new ListDeploymentInstancesRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListDeploymentInstances(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.InstancesList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}