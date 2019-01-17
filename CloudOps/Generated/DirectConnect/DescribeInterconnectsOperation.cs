using Amazon;
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;
using Amazon.Runtime;

namespace CloudOps.DirectConnect
{
    public class DescribeInterconnectsOperation : Operation
    {
        public override string Name => "DescribeInterconnects";

        public override string Description => "Lists the interconnects owned by the AWS account or only the specified interconnect.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DirectConnect";

        public override string ServiceID => "Direct Connect";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDirectConnectConfig config = new AmazonDirectConnectConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonDirectConnectClient client = new AmazonDirectConnectClient(creds, config);
            
            DescribeInterconnectsResponse resp = new DescribeInterconnectsResponse();
            DescribeInterconnectsRequest req = new DescribeInterconnectsRequest
            {                    
                                    
            };
            resp = client.DescribeInterconnects(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.Interconnects)
            {
                AddObject(obj);
            }
            
        }
    }
}