using Amazon;
using Amazon.ElasticsearchService;
using Amazon.ElasticsearchService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElasticsearchServiceListElasticsearchInstanceTypesOperation : Operation
    {
        public override string Name => "ListElasticsearchInstanceTypes";

        public override string Description => "List all Elasticsearch instance types that are supported for given ElasticsearchVersion";
 
        public override string RequestURI => "/2015-01-01/es/instanceTypes/{ElasticsearchVersion}";

        public override string Method => "GET";

        public override string ServiceName => "ElasticsearchService";

        public override string ServiceID => "Elasticsearch Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticsearchServiceClient client = new AmazonElasticsearchServiceClient(creds, region);
            ListElasticsearchInstanceTypesResponse resp = new ListElasticsearchInstanceTypesResponse();
            do
            {
                ListElasticsearchInstanceTypesRequest req = new ListElasticsearchInstanceTypesRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListElasticsearchInstanceTypes(req);
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