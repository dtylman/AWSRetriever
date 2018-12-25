using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServiceCatalogSearchProductsOperation : Operation
    {
        public override string Name => "SearchProducts";

        public override string Description => "Gets information about the products to which the caller has access.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            SearchProductsOutput resp = new SearchProductsOutput();
            do
            {
                SearchProductsInput req = new SearchProductsInput
                {
                    PageToken = resp.NextPageToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.SearchProducts(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ProductViewAggregations)
                {
                    AddObject(obj);
                }
                
                foreach (var obj in resp.NextPageToken)
                {
                    AddObject(obj);
                }
                
                foreach (var obj in resp.ProductViewSummaries)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}