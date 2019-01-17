using Amazon;
using Amazon.ECS;
using Amazon.ECS.Model;
using Amazon.Runtime;

namespace CloudOps.ECS
{
    public class ListClustersOperation : Operation
    {
        public override string Name => "ListClusters";

        public override string Description => "Returns a list of existing clusters.";
 
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
            
            ListClustersResponse resp = new ListClustersResponse();
            do
            {
                ListClustersRequest req = new ListClustersRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListClusters(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ClusterArns)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}