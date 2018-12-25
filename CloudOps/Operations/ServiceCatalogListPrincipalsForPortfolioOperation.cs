using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServiceCatalogListPrincipalsForPortfolioOperation : Operation
    {
        public override string Name => "ListPrincipalsForPortfolio";

        public override string Description => "Lists all principal ARNs associated with the specified portfolio.";
 
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
                ListPrincipalsForPortfolioRequest req = new ListPrincipalsForPortfolioRequest
                {
                    PageToken = resp.NextPageToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.ListPrincipalsForPortfolio(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}