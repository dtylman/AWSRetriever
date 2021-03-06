using Amazon;
using Amazon.ServiceDiscovery;
using Amazon.ServiceDiscovery.Model;
using Amazon.Runtime;

namespace CloudOps.ServiceDiscovery
{
    public class ListServicesOperation : Operation
    {
        public override string Name => "ListServices";

        public override string Description => "Lists summary information for all the services that are associated with one or more specified namespaces.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceDiscovery";

        public override string ServiceID => "ServiceDiscovery";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceDiscoveryConfig config = new AmazonServiceDiscoveryConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonServiceDiscoveryClient client = new AmazonServiceDiscoveryClient(creds, config);
            
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
                
                foreach (var obj in resp.Services)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}