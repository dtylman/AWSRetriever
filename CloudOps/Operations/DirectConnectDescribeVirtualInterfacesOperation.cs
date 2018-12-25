using Amazon;
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DirectConnectDescribeVirtualInterfacesOperation : Operation
    {
        public override string Name => "DescribeVirtualInterfaces";

        public override string Description => "Displays all virtual interfaces for an AWS account. Virtual interfaces deleted fewer than 15 minutes before you make the request are also returned. If you specify a connection ID, only the virtual interfaces associated with the connection are returned. If you specify a virtual interface ID, then only a single virtual interface is returned. A virtual interface (VLAN) transmits the traffic between the AWS Direct Connect location and the customer network.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DirectConnect";

        public override string ServiceID => "Direct Connect";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDirectConnectClient client = new AmazonDirectConnectClient(creds, region);
            VirtualInterfaces resp = new VirtualInterfaces();
            do
            {
                DescribeVirtualInterfacesRequest req = new DescribeVirtualInterfacesRequest
                {
                    &lt;nil&gt; = resp.&lt;nil&gt;
                                        
                };

                resp = client.DescribeVirtualInterfaces(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.virtualInterfaces)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.&lt;nil&gt;));
        }
    }
}