using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RDSDescribeDBParametersOperation : Operation
    {
        public override string Name => "DescribeDBParameters";

        public override string Description => "Returns the detailed parameter list for a particular DB parameter group.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            Response resp = new Response();
            do
            {
                DescribeDBParametersMessageRequest req = new DescribeDBParametersMessageRequest
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