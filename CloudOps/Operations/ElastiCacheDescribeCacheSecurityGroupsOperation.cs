using Amazon;
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElastiCacheDescribeCacheSecurityGroupsOperation : Operation
    {
        public override string Name => "DescribeCacheSecurityGroups";

        public override string Description => "Returns a list of cache security group descriptions. If a cache security group name is specified, the list contains only the description of that group.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElastiCache";

        public override string ServiceID => "ElastiCache";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElastiCacheClient client = new AmazonElastiCacheClient(creds, region);
            CacheSecurityGroupMessage resp = new CacheSecurityGroupMessage();
            do
            {
                DescribeCacheSecurityGroupsMessage req = new DescribeCacheSecurityGroupsMessage
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeCacheSecurityGroups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.CacheSecurityGroups)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}