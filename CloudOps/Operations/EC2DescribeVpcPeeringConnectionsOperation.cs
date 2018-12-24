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
            DescribeVpcPeeringConnectionsResult resp = new DescribeVpcPeeringConnectionsResult();
            do
            {
                DescribeVpcPeeringConnectionsRequest req = new DescribeVpcPeeringConnectionsRequest
                {
                    &lt;nil&gt; = resp.&lt;nil&gt;,
                    &lt;nil&gt; = maxItems
                };
                resp = client.DescribeVpcPeeringConnections(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.VpcPeeringConnections)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.&lt;nil&gt;));
        }
    }
}