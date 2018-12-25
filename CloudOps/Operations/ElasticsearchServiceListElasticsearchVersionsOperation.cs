using Amazon;
using Amazon.ElasticsearchService;
using Amazon.ElasticsearchService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElasticsearchServiceListElasticsearchVersionsOperation : Operation
    {
        public override string Name => "ListElasticsearchVersions";

        public override string Description => "List all supported Elasticsearch versions";
 
        public override string RequestURI => "/2015-01-01/es/versions";

        public override string Method => "GET";

        public override string ServiceName => "ElasticsearchService";

        public override string ServiceID => "Elasticsearch Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticsearchServiceClient client = new AmazonElasticsearchServiceClient(creds, region);
            ListElasticsearchVersionsResponse resp = new ListElasticsearchVersionsResponse();
            do
            {
                ListElasticsearchVersionsRequest req = new ListElasticsearchVersionsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListElasticsearchVersions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}