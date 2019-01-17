using Amazon;
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;
using Amazon.Runtime;

namespace CloudOps.ElastiCache
{
    public class DescribeSnapshotsOperation : Operation
    {
        public override string Name => "DescribeSnapshots";

        public override string Description => "Returns information about cluster or replication group snapshots. By default, DescribeSnapshots lists all of your snapshots; it can optionally describe a single snapshot, or just the snapshots associated with a particular cache cluster.  This operation is valid for Redis only. ";
 
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
            
            DescribeSnapshotsResponse resp = new DescribeSnapshotsResponse();
            do
            {
                DescribeSnapshotsRequest req = new DescribeSnapshotsRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeSnapshots(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Snapshots)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}