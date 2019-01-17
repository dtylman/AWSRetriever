using Amazon;
using Amazon.ServiceDiscovery;
using Amazon.ServiceDiscovery.Model;
using Amazon.Runtime;

namespace CloudOps.ServiceDiscovery
{
    public class ListNamespacesOperation : Operation
    {
        public override string Name => "ListNamespaces";

        public override string Description => "Lists summary information about the namespaces that were created by the current AWS account.";
 
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
            
            ListNamespacesResponse resp = new ListNamespacesResponse();
            do
            {
                ListNamespacesRequest req = new ListNamespacesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListNamespaces(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Namespaces)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}