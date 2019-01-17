using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.RDS
{
    public class DescribeDBInstanceAutomatedBackupsOperation : Operation
    {
        public override string Name => "DescribeDBInstanceAutomatedBackups";

        public override string Description => "Displays backups for both current and deleted instances. For example, use this operation to find details about automated backups for previously deleted instances. Current instances with retention periods greater than zero (0) are returned for both the DescribeDBInstanceAutomatedBackups and DescribeDBInstances operations. All parameters are optional.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSConfig config = new AmazonRDSConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonRDSClient client = new AmazonRDSClient(creds, config);
            
            DescribeDBInstanceAutomatedBackupsResponse resp = new DescribeDBInstanceAutomatedBackupsResponse();
            do
            {
                DescribeDBInstanceAutomatedBackupsRequest req = new DescribeDBInstanceAutomatedBackupsRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeDBInstanceAutomatedBackups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DBInstanceAutomatedBackups)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}