using Amazon;
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElasticsearchGetUpgradeHistoryOperation : Operation
    {
        public override string Name => "GetUpgradeHistory";

        public override string Description => "Retrieves the complete history of the last 10 upgrades that were performed on the domain.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "Elasticsearch";

        public override string ServiceID => "Elasticsearch Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticsearchClient client = new AmazonElasticsearchClient(creds, region);
            Response resp = new Response();
            do
            {
                GetUpgradeHistoryRequest req = new GetUpgradeHistoryRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetUpgradeHistory(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}