using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.ServiceCatalog
{
    public class ListProvisioningArtifactsForServiceActionOperation : Operation
    {
        public override string Name => "ListProvisioningArtifactsForServiceAction";

        public override string Description => "Lists all provisioning artifacts (also known as versions) for the specified self-service action.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogConfig config = new AmazonServiceCatalogConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, config);
            
            ListProvisioningArtifactsForServiceActionResponse resp = new ListProvisioningArtifactsForServiceActionResponse();
            do
            {
                ListProvisioningArtifactsForServiceActionRequest req = new ListProvisioningArtifactsForServiceActionRequest
                {
                    PageToken = resp.NextPageToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.ListProvisioningArtifactsForServiceAction(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ProvisioningArtifactViews)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}