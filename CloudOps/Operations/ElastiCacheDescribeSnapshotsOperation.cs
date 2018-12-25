using Amazon;
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElastiCacheDescribeSnapshotsOperation : Operation
    {
        public override string Name => "DescribeSnapshots";

        public override string Description => "Returns information about cluster or replication group snapshots. By default, DescribeSnapshots lists all of your snapshots; it can optionally describe a single snapshot, or just the snapshots associated with a particular cache cluster.  This operation is valid for Redis only. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElastiCache";

        public override string ServiceID => "ElastiCache";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElastiCacheClient client = new AmazonElastiCacheClient(creds, region);
            DescribeSnapshotsListMessageResponse resp = new DescribeSnapshotsListMessageResponse();
            do
            {
                DescribeSnapshotsMessageRequest req = new DescribeSnapshotsMessageRequest
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