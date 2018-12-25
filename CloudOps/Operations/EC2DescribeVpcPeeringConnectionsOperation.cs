using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class EC2DescribeVpcPeeringConnectionsOperation : Operation
    {
        public override string Name => "DescribeVpcPeeringConnections";

        public override string Description => "Describes one or more of your VPC peering connections.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribeVpcPeeringConnectionsResultResponse resp = new DescribeVpcPeeringConnectionsResultResponse();
            DescribeVpcPeeringConnectionsRequest req = new DescribeVpcPeeringConnectionsRequest
            {                    
                                    
            };
            resp = client.DescribeVpcPeeringConnections(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.VpcPeeringConnections)
            {
                AddObject(obj);
            }
            
        }
    }
}