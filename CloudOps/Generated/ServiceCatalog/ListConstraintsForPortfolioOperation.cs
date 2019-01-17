using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.ServiceCatalog
{
    public class ListConstraintsForPortfolioOperation : Operation
    {
        public override string Name => "ListConstraintsForPortfolio";

        public override string Description => "Lists the constraints for the specified portfolio and product.";
 
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
            
            ListConstraintsForPortfolioResponse resp = new ListConstraintsForPortfolioResponse();
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
                
                foreach (var obj in resp.ConstraintDetails)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}