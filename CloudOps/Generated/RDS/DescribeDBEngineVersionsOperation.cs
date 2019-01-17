using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.RDS
{
    public class DescribeDBEngineVersionsOperation : Operation
    {
        public override string Name => "DescribeDBEngineVersions";

        public override string Description => "Returns a list of the available DB engines.";
 
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
            
            DescribeDBEngineVersionsResponse resp = new DescribeDBEngineVersionsResponse();
            do
            {
                DescribeDBEngineVersionsRequest req = new DescribeDBEngineVersionsRequest
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