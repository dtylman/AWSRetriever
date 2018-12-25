using Amazon;
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElastiCacheDescribeCacheParametersOperation : Operation
    {
        public override string Name => "DescribeCacheParameters";

        public override string Description => "Returns the detailed parameter list for a particular cache parameter group.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "ElastiCache";

        public override string ServiceID => "ElastiCache";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElastiCacheClient client = new AmazonElastiCacheClient(creds, region);
            Response resp = new Response();
            do
            {
                DescribeCacheParametersMessageRequest req = new DescribeCacheParametersMessageRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeCacheParameters(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Parameters)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}