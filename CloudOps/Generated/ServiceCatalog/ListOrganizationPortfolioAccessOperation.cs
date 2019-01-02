using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.ServiceCatalog
{
    public class ListOrganizationPortfolioAccessOperation : Operation
    {
        public override string Name => "ListOrganizationPortfolioAccess";

        public override string Description => "Lists the organization nodes that have access to the specified portfolio. This API can only be called by the master account in the organization.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            ListOrganizationPortfolioAccessResponse resp = new ListOrganizationPortfolioAccessResponse();
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
                
                foreach (var obj in resp.OrganizationNodes)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}