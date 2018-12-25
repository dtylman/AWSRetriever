using Amazon;
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElastiCacheDescribeCacheEngineVersionsOperation : Operation
    {
        public override string Name => "DescribeCacheEngineVersions";

        public override string Description => "Returns a list of the available cache engines and their versions.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElastiCache";

        public override string ServiceID => "ElastiCache";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElastiCacheClient client = new AmazonElastiCacheClient(creds, region);
            CacheEngineVersionMessage resp = new CacheEngineVersionMessage();
            do
            {
                DescribeCacheEngineVersionsMessage req = new DescribeCacheEngineVersionsMessage
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeCacheEngineVersions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.CacheEngineVersions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}