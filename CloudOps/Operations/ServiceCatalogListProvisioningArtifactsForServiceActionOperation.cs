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
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            ListProvisioningArtifactsForServiceActionOutput resp = new ListProvisioningArtifactsForServiceActionOutput();
            do
            {
                ListProvisioningArtifactsForServiceActionInput req = new ListProvisioningArtifactsForServiceActionInput
                {
                    PageToken = resp.NextPageToken,
                    PageSize = maxItems
                };
                resp = client.ListProvisioningArtifactsForServiceAction(req);
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