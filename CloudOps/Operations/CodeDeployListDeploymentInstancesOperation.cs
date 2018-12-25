using Amazon;
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CodeDeployListDeploymentInstancesOperation : Operation
    {
        public override string Name => "ListDeploymentInstances";

        public override string Description => "  The newer BatchGetDeploymentTargets should be used instead because it works with all compute types. ListDeploymentInstances throws an exception if it is used with a compute platform other than EC2/On-premises or AWS Lambda.    Lists the instance for a deployment associated with the applicable IAM user or AWS account. ";
 
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