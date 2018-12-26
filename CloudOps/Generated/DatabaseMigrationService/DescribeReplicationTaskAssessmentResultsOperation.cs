using Amazon;
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;
using Amazon.Runtime;

namespace CloudOps.DatabaseMigrationService
{
    public class DescribeReplicationTaskAssessmentResultsOperation : Operation
    {
        public override string Name => "DescribeReplicationTaskAssessmentResults";

        public override string Description => "Returns the task assessment results from Amazon S3. This action always returns the latest results.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DatabaseMigrationService";

        public override string ServiceID => "Database Migration Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDatabaseMigrationServiceClient client = new AmazonDatabaseMigrationServiceClient(creds, region);
            DescribeReplicationTaskAssessmentResultsResponse resp = new DescribeReplicationTaskAssessmentResultsResponse();
            do
            {
                DescribeReplicationTaskAssessmentResultsRequest req = new DescribeReplicationTaskAssessmentResultsRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeReplicationTaskAssessmentResults(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.BucketName)
                {
                    AddObject(obj);
                }
                
                foreach (var obj in resp.ReplicationTaskAssessmentResults)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}