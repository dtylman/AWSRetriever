using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.ServiceCatalog
{
    public class SearchProductsOperation : Operation
    {
        public override string Name => "SearchProducts";

        public override string Description => "Gets information about the products to which the caller has access.";
 
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
            
            SearchProductsResponse resp = new SearchProductsResponse();
            do
            {
                SearchProductsRequest req = new SearchProductsRequest
                {
                    PageToken = resp.NextPageToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.SearchProducts(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ProductViewSummaries)
                {
                    AddObject(obj);
                }
                
                foreach (var obj in resp.ProductViewAggregations)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}