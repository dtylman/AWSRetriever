using Amazon;
using Amazon.ServiceDiscovery;
using Amazon.ServiceDiscovery.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServiceDiscoveryListInstancesOperation : Operation
    {
        public override string Name => "ListInstances";

        public override string Description => "Lists summary information about the instances that you registered by using a specified service.";
 
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
                ListInstancesRequest req = new ListInstancesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListInstances(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}