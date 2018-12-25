using Amazon;
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DatabaseMigrationServiceDescribeReplicationInstancesOperation : Operation
    {
        public override string Name => "DescribeReplicationInstances";

        public override string Description => "Returns information about replication instances for your account in the current region.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DatabaseMigrationService";

        public override string ServiceID => "Database Migration Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDatabaseMigrationServiceClient client = new AmazonDatabaseMigrationServiceClient(creds, region);
            DescribeReplicationInstancesResponse resp = new DescribeReplicationInstancesResponse();
            do
            {
                DescribeReplicationInstancesMessageRequest req = new DescribeReplicationInstancesMessageRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeReplicationInstances(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ReplicationInstances)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}