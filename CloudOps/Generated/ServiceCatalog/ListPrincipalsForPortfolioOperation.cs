using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.ServiceCatalog
{
    public class ListPrincipalsForPortfolioOperation : Operation
    {
        public override string Name => "ListPrincipalsForPortfolio";

        public override string Description => "Lists all principal ARNs associated with the specified portfolio.";
 
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
            
            ListPrincipalsForPortfolioResponse resp = new ListPrincipalsForPortfolioResponse();
            do
            {
                ListPrincipalsForPortfolioRequest req = new ListPrincipalsForPortfolioRequest
                {
                    PageToken = resp.NextPageToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.ListPrincipalsForPortfolio(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Principals)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}