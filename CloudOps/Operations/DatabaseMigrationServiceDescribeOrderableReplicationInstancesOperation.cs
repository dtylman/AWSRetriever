using Amazon;
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DatabaseMigrationServiceDescribeOrderableReplicationInstancesOperation : Operation
    {
        public override string Name => "DescribeOrderableReplicationInstances";

        public override string Description => "Returns information about the replication instance types that can be created in the specified region.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DatabaseMigrationService";

        public override string ServiceID => "Database Migration Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDatabaseMigrationServiceClient client = new AmazonDatabaseMigrationServiceClient(creds, region);
            DescribeOrderableReplicationInstancesResponse resp = new DescribeOrderableReplicationInstancesResponse();
            do
            {
                DescribeOrderableReplicationInstancesMessage req = new DescribeOrderableReplicationInstancesMessage
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeOrderableReplicationInstances(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Marker)
                {
                    AddObject(obj);
                }
                
                foreach (var obj in resp.OrderableReplicationInstances)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}