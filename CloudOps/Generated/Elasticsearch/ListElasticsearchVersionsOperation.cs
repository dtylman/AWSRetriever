using Amazon;
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;
using Amazon.Runtime;

namespace CloudOps.Elasticsearch
{
    public class ListElasticsearchVersionsOperation : Operation
    {
        public override string Name => "ListElasticsearchVersions";

        public override string Description => "List all supported Elasticsearch versions";
 
        public override string RequestURI => "/2015-01-01/es/versions";

        public override string Method => "GET";

        public override string ServiceName => "Elasticsearch";

        public override string ServiceID => "Elasticsearch Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticsearchConfig config = new AmazonElasticsearchConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonElasticsearchClient client = new AmazonElasticsearchClient(creds, config);
            
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
                
                foreach (var obj in resp.ElasticsearchVersions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}