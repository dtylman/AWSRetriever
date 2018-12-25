using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServiceCatalogListPortfoliosForProductOperation : Operation
    {
        public override string Name => "ListPortfoliosForProduct";

        public override string Description => "Lists all portfolios that the specified product is associated with.";
 
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
                ListPortfoliosForProductRequest req = new ListPortfoliosForProductRequest
                {
                    PageToken = resp.NextPageToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.ListPortfoliosForProduct(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}