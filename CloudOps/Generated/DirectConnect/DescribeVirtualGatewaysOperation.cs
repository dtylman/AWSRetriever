using Amazon;
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;
using Amazon.Runtime;

namespace CloudOps.DirectConnect
{
    public class DescribeVirtualGatewaysOperation : Operation
    {
        public override string Name => "DescribeVirtualGateways";

        public override string Description => "Lists the virtual private gateways owned by the AWS account. You can create one or more AWS Direct Connect private virtual interfaces linked to a virtual private gateway.";
 
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
            
            DescribeVirtualGatewaysResponse resp = new DescribeVirtualGatewaysResponse();
            DescribeVirtualGatewaysRequest req = new DescribeVirtualGatewaysRequest
            {                    
                                    
            };
            resp = client.DescribeVirtualGateways(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.VirtualGateways)
            {
                AddObject(obj);
            }
            
        }
    }
}