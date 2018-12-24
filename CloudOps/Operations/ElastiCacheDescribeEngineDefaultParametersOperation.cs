using Amazon;
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElastiCacheDescribeEngineDefaultParametersOperation : Operation
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
            DescribeEngineDefaultParametersResult resp = new DescribeEngineDefaultParametersResult();
            do
            {
                DescribeEngineDefaultParametersMessage req = new DescribeEngineDefaultParametersMessage
                {
                    Marker = resp.EngineDefaults.Marker,
                    MaxRecords = maxItems
                };
                resp = client.DescribeEngineDefaultParameters(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.EngineDefaults.Parameters)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.EngineDefaults.Marker));
        }
    }
}