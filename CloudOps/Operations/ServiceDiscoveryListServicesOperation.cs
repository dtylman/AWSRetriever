using Amazon;
using Amazon.ServiceDiscovery;
using Amazon.ServiceDiscovery.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServiceDiscoveryListServicesOperation : Operation
    {
        public override string Name => "ListServices";

        public override string Description => "Lists summary information for all the services that are associated with one or more specified namespaces.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceDiscovery";

        public override string ServiceID => "ServiceDiscovery";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceDiscoveryClient client = new AmazonServiceDiscoveryClient(creds, region);
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
                
                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}