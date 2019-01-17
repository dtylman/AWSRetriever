using Amazon;
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;
using Amazon.Runtime;

namespace CloudOps.DirectConnect
{
    public class DescribeConnectionsOperation : Operation
    {
        public override string Name => "DescribeConnections";

        public override string Description => "Displays the specified connection or all connections in this Region.";
 
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
            
            DescribeConnectionsResponse resp = new DescribeConnectionsResponse();
            DescribeConnectionsRequest req = new DescribeConnectionsRequest
            {                    
                                    
            };
            resp = client.DescribeConnections(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.Connections)
            {
                AddObject(obj);
            }
            
        }
    }
}