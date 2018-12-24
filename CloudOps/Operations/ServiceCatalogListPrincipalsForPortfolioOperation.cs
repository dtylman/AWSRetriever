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
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            ListPrincipalsForPortfolioOutput resp = new ListPrincipalsForPortfolioOutput();
            do
            {
                ListPrincipalsForPortfolioInput req = new ListPrincipalsForPortfolioInput
                {
                    PageToken = resp.NextPageToken,
                    PageSize = maxItems
                };
                resp = client.ListPrincipalsForPortfolio(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}