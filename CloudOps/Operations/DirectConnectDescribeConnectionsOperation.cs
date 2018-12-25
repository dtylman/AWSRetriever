using Amazon;
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DirectConnectDescribeConnectionsOperation : Operation
    {
        public override string Name => "DescribeConnections";

        public override string Description => "Displays the specified connection or all connections in this Region.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DirectConnect";

        public override string ServiceID => "Direct Connect";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDirectConnectClient client = new AmazonDirectConnectClient(creds, region);
            Connections resp = new Connections();
            do
            {
                DescribeConnectionsRequest req = new DescribeConnectionsRequest
                {
                    &lt;nil&gt; = resp.&lt;nil&gt;
                                        
                };

                resp = client.DescribeConnections(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.connections)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.&lt;nil&gt;));
        }
    }
}