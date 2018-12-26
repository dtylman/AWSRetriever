using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.ServiceCatalog
{
    public class SearchProductsAsAdminOperation : Operation
    {
        public override string Name => "SearchProductsAsAdmin";

        public override string Description => "Gets information about the products for the specified portfolio or all products.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            SearchProductsAsAdminResponse resp = new SearchProductsAsAdminResponse();
            do
            {
                SearchProductsAsAdminRequest req = new SearchProductsAsAdminRequest
                {
                    PageToken = resp.NextPageToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.SearchProductsAsAdmin(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ProductViewDetails)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}