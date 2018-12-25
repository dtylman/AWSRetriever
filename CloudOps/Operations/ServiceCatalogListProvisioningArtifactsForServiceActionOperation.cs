using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServiceCatalogListProvisioningArtifactsForServiceActionOperation : Operation
    {
        public override string Name => "ListProvisioningArtifactsForServiceAction";

        public override string Description => "Lists all provisioning artifacts (also known as versions) for the specified self-service action.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            Response resp = new Response();
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
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}