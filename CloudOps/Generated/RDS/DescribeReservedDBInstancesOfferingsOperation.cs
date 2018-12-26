using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.RDS
{
    public class DescribeReservedDBInstancesOfferingsOperation : Operation
    {
        public override string Name => "DescribeReservedDBInstancesOfferings";

        public override string Description => "Lists available reserved DB instance offerings.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            DescribeReservedDBInstancesOfferingsResponse resp = new DescribeReservedDBInstancesOfferingsResponse();
            do
            {
                DescribeReservedDBInstancesOfferingsRequest req = new DescribeReservedDBInstancesOfferingsRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeReservedDBInstancesOfferings(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ReservedDBInstancesOfferings)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}