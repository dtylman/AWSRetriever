using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServiceCatalogListAcceptedPortfolioSharesOperation : Operation
    {
        public override string Name => "ListAcceptedPortfolioShares";

        public override string Description => "Lists all portfolios for which sharing was accepted by this account.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            ListAcceptedPortfolioSharesOutput resp = new ListAcceptedPortfolioSharesOutput();
            do
            {
                ListAcceptedPortfolioSharesInput req = new ListAcceptedPortfolioSharesInput
                {
                    PageToken = resp.NextPageToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.ListAcceptedPortfolioShares(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}