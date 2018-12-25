using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServiceCatalogListOrganizationPortfolioAccessOperation : Operation
    {
        public override string Name => "ListOrganizationPortfolioAccess";

        public override string Description => "Lists the organization nodes that have access to the specified portfolio. This API can only be called by the master account in the organization.";
 
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
                ListOrganizationPortfolioAccessRequest req = new ListOrganizationPortfolioAccessRequest
                {
                    PageToken = resp.NextPageToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.ListOrganizationPortfolioAccess(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}