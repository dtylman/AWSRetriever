using Amazon;
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DatabaseMigrationServiceDescribeEventsOperation : Operation
    {
        public override string Name => "DescribeEvents";

        public override string Description => " Lists events for a given source identifier and source type. You can also specify a start and end time. For more information on AWS DMS events, see Working with Events and Notifications in the AWS Database Migration User Guide. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DatabaseMigrationService";

        public override string ServiceID => "Database Migration Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDatabaseMigrationServiceClient client = new AmazonDatabaseMigrationServiceClient(creds, region);
            DescribeEventsResponse resp = new DescribeEventsResponse();
            do
            {
                DescribeEventsMessageRequest req = new DescribeEventsMessageRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeEvents(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Events)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}