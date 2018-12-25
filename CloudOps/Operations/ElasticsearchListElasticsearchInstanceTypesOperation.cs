using Amazon;
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElasticsearchListElasticsearchInstanceTypesOperation : Operation
    {
        public override string Name => "ListElasticsearchInstanceTypes";

        public override string Description => "List all Elasticsearch instance types that are supported for given ElasticsearchVersion";
 
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
                ListElasticsearchInstanceTypesRequest req = new ListElasticsearchInstanceTypesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListElasticsearchInstanceTypes(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}