using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class EC2DescribeNatGatewaysOperation : Operation
    {
        public override string Name => "DescribeNatGateways";

        public override string Description => "Describes one or more of your NAT gateways.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribeNatGatewaysResult resp = new DescribeNatGatewaysResult();
            do
            {
                DescribeNatGatewaysRequest req = new DescribeNatGatewaysRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeNatGateways(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.NatGateways)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}