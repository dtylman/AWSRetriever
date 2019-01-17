using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.RDS
{
    public class DescribeDBLogFilesOperation : Operation
    {
        public override string Name => "DescribeDBLogFiles";

        public override string Description => "Returns a list of DB log files for the DB instance.";
 
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
            
            DescribeDBLogFilesResponse resp = new DescribeDBLogFilesResponse();
            do
            {
                DescribeDBLogFilesRequest req = new DescribeDBLogFilesRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeDBLogFiles(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DescribeDBLogFiles)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}