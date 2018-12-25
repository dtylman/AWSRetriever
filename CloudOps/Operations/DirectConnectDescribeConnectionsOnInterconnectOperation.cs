using Amazon;
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DirectConnectDescribeConnectionsOnInterconnectOperation : Operation
    {
        public override string Name => "DescribeConnectionsOnInterconnect";

        public override string Description => "Deprecated. Use DescribeHostedConnections instead. Lists the connections that have been provisioned on the specified interconnect.  Intended for use by AWS Direct Connect partners only. ";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "DirectConnect";

        public override string ServiceID => "Direct Connect";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDirectConnectClient client = new AmazonDirectConnectClient(creds, region);
            Response resp = new Response();
            DescribeConnectionsOnInterconnectRequest req = new DescribeConnectionsOnInterconnectRequest
            {                    
                                    
            };
            resp = client.DescribeConnectionsOnInterconnect(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.Connections)
            {
                AddObject(obj);
            }
            
        }
    }
}