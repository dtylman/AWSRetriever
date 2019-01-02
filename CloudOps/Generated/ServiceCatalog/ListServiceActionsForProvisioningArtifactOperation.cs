using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.ServiceCatalog
{
    public class ListServiceActionsForProvisioningArtifactOperation : Operation
    {
        public override string Name => "ListServiceActionsForProvisioningArtifact";

        public override string Description => "Returns a paginated list of self-service actions associated with the specified Product ID and Provisioning Artifact ID.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            ListServiceActionsForProvisioningArtifactResponse resp = new ListServiceActionsForProvisioningArtifactResponse();
            do
            {
                ListServiceActionsForProvisioningArtifactRequest req = new ListServiceActionsForProvisioningArtifactRequest
                {
                    PageToken = resp.NextPageToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.ListServiceActionsForProvisioningArtifact(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ServiceActionSummaries)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}