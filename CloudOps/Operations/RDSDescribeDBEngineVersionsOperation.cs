using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RDSDescribeDBEngineVersionsOperation : Operation
    {
        public override string Name => "DescribeDBEngineVersions";

        public override string Description => "Returns a list of the available DB engines.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            DBEngineVersionMessageResponse resp = new DBEngineVersionMessageResponse();
            do
            {
                DescribeDBEngineVersionsMessageRequest req = new DescribeDBEngineVersionsMessageRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeDBEngineVersions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DBEngineVersions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}