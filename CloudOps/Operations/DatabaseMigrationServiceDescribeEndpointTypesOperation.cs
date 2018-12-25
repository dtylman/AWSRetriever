using Amazon;
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DatabaseMigrationServiceDescribeEndpointTypesOperation : Operation
    {
        public override string Name => "DescribeEndpointTypes";

        public override string Description => "Returns information about the type of endpoints available.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DatabaseMigrationService";

        public override string ServiceID => "Database Migration Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDatabaseMigrationServiceClient client = new AmazonDatabaseMigrationServiceClient(creds, region);
            DescribeEndpointTypesResponse resp = new DescribeEndpointTypesResponse();
            do
            {
                DescribeEndpointTypesMessage req = new DescribeEndpointTypesMessage
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeEndpointTypes(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Marker)
                {
                    AddObject(obj);
                }
                
                foreach (var obj in resp.SupportedEndpointTypes)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}