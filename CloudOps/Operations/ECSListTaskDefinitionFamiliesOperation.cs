using Amazon;
using Amazon.ECS;
using Amazon.ECS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ECSListTaskDefinitionFamiliesOperation : Operation
    {
        public override string Name => "ListTaskDefinitionFamilies";

        public override string Description => "Returns a list of task definition families that are registered to your account (which may include task definition families that no longer have any ACTIVE task definition revisions). You can filter out task definition families that do not contain any ACTIVE task definition revisions by setting the status parameter to ACTIVE. You can also filter the results with the familyPrefix parameter.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ECS";

        public override string ServiceID => "ECS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonECSClient client = new AmazonECSClient(creds, region);
            ListTaskDefinitionFamiliesResponse resp = new ListTaskDefinitionFamiliesResponse();
            do
            {
                ListTaskDefinitionFamiliesRequest req = new ListTaskDefinitionFamiliesRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.ListTaskDefinitionFamilies(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.families)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}