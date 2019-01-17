using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.RDS
{
    public class DescribeOrderableDBInstanceOptionsOperation : Operation
    {
        public override string Name => "DescribeOrderableDBInstanceOptions";

        public override string Description => "Returns a list of orderable DB instance options for the specified engine.";
 
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
            
            DescribeOrderableDBInstanceOptionsResponse resp = new DescribeOrderableDBInstanceOptionsResponse();
            do
            {
                DescribeOrderableDBInstanceOptionsRequest req = new DescribeOrderableDBInstanceOptionsRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeOrderableDBInstanceOptions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.OrderableDBInstanceOptions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}