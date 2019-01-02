using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.ServiceCatalog
{
    public class ListPortfoliosForProductOperation : Operation
    {
        public override string Name => "ListPortfoliosForProduct";

        public override string Description => "Lists all portfolios that the specified product is associated with.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            ListPortfoliosForProductResponse resp = new ListPortfoliosForProductResponse();
            do
            {
                ListPortfoliosForProductRequest req = new ListPortfoliosForProductRequest
                {
                    PageToken = resp.NextPageToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.ListPortfoliosForProduct(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.PortfolioDetails)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}