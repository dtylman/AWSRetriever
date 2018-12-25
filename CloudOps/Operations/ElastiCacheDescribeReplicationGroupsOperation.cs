using Amazon;
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElastiCacheDescribeReplicationGroupsOperation : Operation
    {
        public override string Name => "DescribeReplicationGroups";

        public override string Description => "Returns information about a particular replication group. If no identifier is specified, DescribeReplicationGroups returns information about all replication groups.  This operation is valid for Redis only. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElastiCache";

        public override string ServiceID => "ElastiCache";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElastiCacheClient client = new AmazonElastiCacheClient(creds, region);
            ReplicationGroupMessage resp = new ReplicationGroupMessage();
            do
            {
                DescribeReplicationGroupsMessage req = new DescribeReplicationGroupsMessage
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeReplicationGroups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ReplicationGroups)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}