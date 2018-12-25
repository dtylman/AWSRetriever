using Amazon;
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DatabaseMigrationServiceDescribeReplicationInstanceTaskLogsOperation : Operation
    {
        public override string Name => "DescribeReplicationInstanceTaskLogs";

        public override string Description => "Returns information about the task logs for the specified task.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "DatabaseMigrationService";

        public override string ServiceID => "Database Migration Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDatabaseMigrationServiceClient client = new AmazonDatabaseMigrationServiceClient(creds, region);
            Response resp = new Response();
            do
            {
                DescribeReplicationInstanceTaskLogsMessageRequest req = new DescribeReplicationInstanceTaskLogsMessageRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeReplicationInstanceTaskLogs(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}