using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServiceCatalogListConstraintsForPortfolioOperation : Operation
    {
        public override string Name => "ListConstraintsForPortfolio";

        public override string Description => "Lists the constraints for the specified portfolio and product.";
 
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
                ListConstraintsForPortfolioRequest req = new ListConstraintsForPortfolioRequest
                {
                    PageToken = resp.NextPageToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.ListConstraintsForPortfolio(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}