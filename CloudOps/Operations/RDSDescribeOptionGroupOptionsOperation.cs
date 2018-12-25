using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RDSDescribeOptionGroupOptionsOperation : Operation
    {
        public override string Name => "DescribeOptionGroupOptions";

        public override string Description => "Describes all available options.";
 
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
                DescribeOptionGroupOptionsMessageRequest req = new DescribeOptionGroupOptionsMessageRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeOptionGroupOptions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.OptionGroupOptions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}