using Amazon;
using Amazon.ElasticsearchService;
using Amazon.ElasticsearchService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElasticsearchServiceGetUpgradeHistoryOperation : Operation
    {
        public override string Name => "GetUpgradeHistory";

        public override string Description => "Retrieves the complete history of the last 10 upgrades that were performed on the domain.";
 
        public override string RequestURI => "/2015-01-01/es/upgradeDomain/{DomainName}/history";

        public override string Method => "GET";

        public override string ServiceName => "ElasticsearchService";

        public override string ServiceID => "Elasticsearch Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticsearchServiceClient client = new AmazonElasticsearchServiceClient(creds, region);
            GetUpgradeHistoryResponse resp = new GetUpgradeHistoryResponse();
            do
            {
                GetUpgradeHistoryRequest req = new GetUpgradeHistoryRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.GetUpgradeHistory(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}