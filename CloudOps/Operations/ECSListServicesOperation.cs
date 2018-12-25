using Amazon;
using Amazon.ECS;
using Amazon.ECS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ECSListServicesOperation : Operation
    {
        public override string Name => "ListServices";

        public override string Description => "Lists the services that are running in a specified cluster.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ECS";

        public override string ServiceID => "ECS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonECSClient client = new AmazonECSClient(creds, region);
            ListServicesResponse resp = new ListServicesResponse();
            do
            {
                ListServicesRequest req = new ListServicesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListServices(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ServiceArns)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}