using Amazon;
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DirectConnectDescribeVirtualGatewaysOperation : Operation
    {
        public override string Name => "DescribeVirtualGateways";

        public override string Description => "Lists the virtual private gateways owned by the AWS account. You can create one or more AWS Direct Connect private virtual interfaces linked to a virtual private gateway.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "DirectConnect";

        public override string ServiceID => "Direct Connect";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDirectConnectClient client = new AmazonDirectConnectClient(creds, region);
            Response resp = new Response();
            Request req = new Request
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