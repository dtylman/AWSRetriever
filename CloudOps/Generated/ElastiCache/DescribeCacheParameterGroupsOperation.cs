using Amazon;
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;
using Amazon.Runtime;

namespace CloudOps.ElastiCache
{
    public class DescribeCacheParameterGroupsOperation : Operation
    {
        public override string Name => "DescribeCacheParameterGroups";

        public override string Description => "Returns a list of cache parameter group descriptions. If a cache parameter group name is specified, the list contains only the descriptions for that group.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElastiCache";

        public override string ServiceID => "ElastiCache";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElastiCacheConfig config = new AmazonElastiCacheConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonElastiCacheClient client = new AmazonElastiCacheClient(creds, config);
            
            DescribeCacheParameterGroupsResponse resp = new DescribeCacheParameterGroupsResponse();
            do
            {
                DescribeCacheParameterGroupsRequest req = new DescribeCacheParameterGroupsRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeCacheParameterGroups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.CacheParameterGroups)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}