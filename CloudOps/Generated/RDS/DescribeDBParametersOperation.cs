using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.RDS
{
    public class DescribeDBParametersOperation : Operation
    {
        public override string Name => "DescribeDBParameters";

        public override string Description => "";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            DescribeDBParametersResponse resp = new DescribeDBParametersResponse();
            do
            {
                DescribeDBParametersRequest req = new DescribeDBParametersRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeDBParameters(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Parameters)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}