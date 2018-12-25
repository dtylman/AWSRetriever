using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RDSDescribeDBInstancesOperation : Operation
    {
        public override string Name => "DescribeDBInstances";

        public override string Description => "Returns information about provisioned RDS instances. This API supports pagination.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            DBInstanceMessageResponse resp = new DBInstanceMessageResponse();
            do
            {
                DescribeDBInstancesMessageRequest req = new DescribeDBInstancesMessageRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeDBInstances(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DBInstances)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}