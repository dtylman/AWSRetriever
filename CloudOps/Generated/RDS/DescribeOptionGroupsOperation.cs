using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.RDS
{
    public class DescribeOptionGroupsOperation : Operation
    {
        public override string Name => "DescribeOptionGroups";

        public override string Description => "Describes the available option groups.";
 
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
            
            DescribeOptionGroupsResponse resp = new DescribeOptionGroupsResponse();
            do
            {
                DescribeOptionGroupsRequest req = new DescribeOptionGroupsRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeOptionGroups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.OptionGroupsList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}