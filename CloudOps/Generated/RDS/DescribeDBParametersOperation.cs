using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.RDS
{
    public class DescribeDBParametersOperation : Operation
    {
        public override string Name => "DescribeDBParameters";

        public override string Description => "Returns the detailed parameter list for a particular DB parameter group.";
 
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