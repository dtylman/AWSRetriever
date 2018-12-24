using Amazon;
using Amazon.ECS;
using Amazon.ECS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ECSListTaskDefinitionsOperation : Operation
    {
        public override string Name => "ListTaskDefinitions";

        public override string Description => "Returns a list of task definitions that are registered to your account. You can filter the results by family name with the familyPrefix parameter or by status with the status parameter.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ECS";

        public override string ServiceID => "ECS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonECSClient client = new AmazonECSClient(creds, region);
            ListTaskDefinitionsResponse resp = new ListTaskDefinitionsResponse();
            do
            {
                ListTaskDefinitionsRequest req = new ListTaskDefinitionsRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.ListTaskDefinitions(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.taskDefinitionArns)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}