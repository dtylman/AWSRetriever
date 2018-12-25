using Amazon;
using Amazon.Glue;
using Amazon.Glue.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class GlueGetCrawlersOperation : Operation
    {
        public override string Name => "GetCrawlers";

        public override string Description => "Retrieves metadata for all crawlers defined in the customer account.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Glue";

        public override string ServiceID => "Glue";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGlueClient client = new AmazonGlueClient(creds, region);
            GetCrawlersResponse resp = new GetCrawlersResponse();
            do
            {
                GetCrawlersRequest req = new GetCrawlersRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetCrawlers(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Crawlers)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}