using Amazon;
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;
using Amazon.Runtime;

namespace CloudOps.ElastiCache
{
    public class DescribeEngineDefaultParametersOperation : Operation
    {
        public override string Name => "DescribeEngineDefaultParameters";

        public override string Description => "Returns the default engine and system parameter information for the specified cache engine.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElastiCache";

        public override string ServiceID => "ElastiCache";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElastiCacheClient client = new AmazonElastiCacheClient(creds, region);
            DescribeEngineDefaultParametersResponse resp = new DescribeEngineDefaultParametersResponse();
            do
            {
                DescribeEngineDefaultParametersRequest req = new DescribeEngineDefaultParametersRequest
                {
                    Marker = resp.EngineDefaultsMarker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeEngineDefaultParameters(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.EngineDefaultsParameters)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.EngineDefaultsMarker));
        }
    }
}