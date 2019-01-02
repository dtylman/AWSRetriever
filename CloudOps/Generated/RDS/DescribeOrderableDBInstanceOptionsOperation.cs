using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.RDS
{
    public class DescribeOrderableDBInstanceOptionsOperation : Operation
    {
        public override string Name => "DescribeOrderableDBInstanceOptions";

        public override string Description => "";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
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