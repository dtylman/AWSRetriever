using Amazon;
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DatabaseMigrationServiceDescribeReplicationTasksOperation : Operation
    {
        public override string Name => "DescribeReplicationTasks";

        public override string Description => "Returns information about replication tasks for your account in the current region.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DatabaseMigrationService";

        public override string ServiceID => "Database Migration Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDatabaseMigrationServiceClient client = new AmazonDatabaseMigrationServiceClient(creds, region);
            DescribeReplicationTasksResponse resp = new DescribeReplicationTasksResponse();
            do
            {
                DescribeReplicationTasksMessageRequest req = new DescribeReplicationTasksMessageRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeReplicationTasks(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ReplicationTasks)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}