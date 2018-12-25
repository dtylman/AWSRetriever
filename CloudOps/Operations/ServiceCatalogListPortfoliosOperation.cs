using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServiceCatalogListPortfoliosOperation : Operation
    {
        public override string Name => "ListPortfolios";

        public override string Description => "Lists all portfolios in the catalog.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            ListPortfoliosOutput resp = new ListPortfoliosOutput();
            do
            {
                ListPortfoliosInput req = new ListPortfoliosInput
                {
                    PageToken = resp.NextPageToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.ListPortfolios(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.PortfolioDetails)
                {
                    AddObject(obj);
                }
                
                foreach (var obj in resp.NextPageToken)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}