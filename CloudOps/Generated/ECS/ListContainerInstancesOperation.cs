using Amazon;
using Amazon.ECS;
using Amazon.ECS.Model;
using Amazon.Runtime;

namespace CloudOps.ECS
{
    public class ListContainerInstancesOperation : Operation
    {
        public override string Name => "ListContainerInstances";

        public override string Description => "Returns a list of container instances in a specified cluster. You can filter the results of a ListContainerInstances operation with cluster query language statements inside the filter parameter. For more information, see Cluster Query Language in the Amazon Elastic Container Service Developer Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ECS";

        public override string ServiceID => "ECS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonECSConfig config = new AmazonECSConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonECSClient client = new AmazonECSClient(creds, config);
            
            ListContainerInstancesResponse resp = new ListContainerInstancesResponse();
            do
            {
                ListContainerInstancesRequest req = new ListContainerInstancesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListContainerInstances(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ContainerInstanceArns)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}