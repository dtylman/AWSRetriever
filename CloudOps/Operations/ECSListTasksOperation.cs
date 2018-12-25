using Amazon;
using Amazon.ECS;
using Amazon.ECS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ECSListTasksOperation : Operation
    {
        public override string Name => "ListTasks";

        public override string Description => "Returns a list of tasks for a specified cluster. You can filter the results by family name, by a particular container instance, or by the desired status of the task with the family, containerInstance, and desiredStatus parameters. Recently stopped tasks might appear in the returned results. Currently, stopped tasks appear in the returned results for at least one hour. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ECS";

        public override string ServiceID => "ECS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonECSClient client = new AmazonECSClient(creds, region);
            ListTasksResponse resp = new ListTasksResponse();
            do
            {
                ListTasksRequest req = new ListTasksRequest
                {
                    nextToken = resp.nextToken
                    ,
                    maxResults = maxItems
                                        
                };

                resp = client.ListTasks(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.taskArns)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}