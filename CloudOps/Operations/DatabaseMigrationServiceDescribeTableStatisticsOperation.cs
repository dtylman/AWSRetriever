using Amazon;
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DatabaseMigrationServiceDescribeTableStatisticsOperation : Operation
    {
        public override string Name => "DescribeTableStatistics";

        public override string Description => "Returns table statistics on the database migration task, including table name, rows inserted, rows updated, and rows deleted. Note that the &#34;last updated&#34; column the DMS console only indicates the time that AWS DMS last updated the table statistics record for a table. It does not indicate the time of the last update to the table.";
 
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
                DescribeTableStatisticsMessageRequest req = new DescribeTableStatisticsMessageRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeTableStatistics(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}