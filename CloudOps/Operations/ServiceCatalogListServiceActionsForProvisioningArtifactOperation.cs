using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServiceCatalogListServiceActionsForProvisioningArtifactOperation : Operation
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
            ListServiceActionsForProvisioningArtifactOutput resp = new ListServiceActionsForProvisioningArtifactOutput();
            do
            {
                ListServiceActionsForProvisioningArtifactInput req = new ListServiceActionsForProvisioningArtifactInput
                {
                    PageToken = resp.NextPageToken,
                    PageSize = maxItems
                };
                resp = client.ListServiceActionsForProvisioningArtifact(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}