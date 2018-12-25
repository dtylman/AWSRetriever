using Amazon;
using Amazon.ServiceDiscovery;
using Amazon.ServiceDiscovery.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServiceDiscoveryGetInstancesHealthStatusOperation : Operation
    {
        public override string Name => "GetInstancesHealthStatus";

        public override string Description => "Gets the current health status (Healthy, Unhealthy, or Unknown) of one or more instances that are associated with a specified service.  There is a brief delay between when you register an instance and when the health status for the instance is available.  ";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "ServiceDiscovery";

        public override string ServiceID => "ServiceDiscovery";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceDiscoveryClient client = new AmazonServiceDiscoveryClient(creds, region);
            Response resp = new Response();
            do
            {
                GetInstancesHealthStatusRequest req = new GetInstancesHealthStatusRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetInstancesHealthStatus(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}