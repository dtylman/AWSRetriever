using Amazon;
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DatabaseMigrationServiceDescribeReplicationSubnetGroupsOperation : Operation
    {
        public override string Name => "DescribeReplicationSubnetGroups";

        public override string Description => "Returns information about the replication subnet groups.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DatabaseMigrationService";

        public override string ServiceID => "Database Migration Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDatabaseMigrationServiceClient client = new AmazonDatabaseMigrationServiceClient(creds, region);
            DescribeReplicationSubnetGroupsResponse resp = new DescribeReplicationSubnetGroupsResponse();
            do
            {
                DescribeReplicationSubnetGroupsMessage req = new DescribeReplicationSubnetGroupsMessage
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeReplicationSubnetGroups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ReplicationSubnetGroups)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}