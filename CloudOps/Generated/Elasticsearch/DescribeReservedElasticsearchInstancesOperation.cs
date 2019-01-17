using Amazon;
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;
using Amazon.Runtime;

namespace CloudOps.Elasticsearch
{
    public class DescribeReservedElasticsearchInstancesOperation : Operation
    {
        public override string Name => "DescribeReservedElasticsearchInstances";

        public override string Description => "Returns information about reserved Elasticsearch instances for this account.";
 
        public override string RequestURI => "/2015-01-01/es/reservedInstances";

        public override string Method => "GET";

        public override string ServiceName => "Elasticsearch";

        public override string ServiceID => "Elasticsearch Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticsearchConfig config = new AmazonElasticsearchConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonElasticsearchClient client = new AmazonElasticsearchClient(creds, config);
            
            DescribeReservedElasticsearchInstancesResponse resp = new DescribeReservedElasticsearchInstancesResponse();
            do
            {
                DescribeReservedElasticsearchInstancesRequest req = new DescribeReservedElasticsearchInstancesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeReservedElasticsearchInstances(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ReservedElasticsearchInstances)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}