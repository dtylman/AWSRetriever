using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RDSDescribeOptionGroupsOperation : Operation
    {
        public override string Name => "DescribeOptionGroups";

        public override string Description => "Describes the available option groups.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            OptionGroupsResponse resp = new OptionGroupsResponse();
            do
            {
                DescribeOptionGroupsMessageRequest req = new DescribeOptionGroupsMessageRequest
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