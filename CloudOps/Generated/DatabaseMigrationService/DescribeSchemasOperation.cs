using Amazon;
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;
using Amazon.Runtime;

namespace CloudOps.DatabaseMigrationService
{
    public class DescribeSchemasOperation : Operation
    {
        public override string Name => "DescribeSchemas";

        public override string Description => "Returns information about the schema for the specified endpoint. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DatabaseMigrationService";

        public override string ServiceID => "Database Migration Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDatabaseMigrationServiceClient client = new AmazonDatabaseMigrationServiceClient(creds, region);
            DescribeSchemasResponse resp = new DescribeSchemasResponse();
            do
            {
                DescribeSchemasRequest req = new DescribeSchemasRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeSchemas(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Schemas)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}