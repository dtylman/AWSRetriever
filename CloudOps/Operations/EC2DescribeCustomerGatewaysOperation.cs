using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class EC2DescribeCustomerGatewaysOperation : Operation
    {
        public override string Name => "DescribeCustomerGateways";

        public override string Description => "Describes one or more of your VPN customer gateways. For more information about VPN customer gateways, see AWS Managed VPN Connections in the Amazon Virtual Private Cloud User Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribeCustomerGatewaysResultResponse resp = new DescribeCustomerGatewaysResultResponse();
            DescribeCustomerGatewaysRequest req = new DescribeCustomerGatewaysRequest
            {                    
                                    
            };
            resp = client.DescribeCustomerGateways(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.CustomerGateways)
            {
                AddObject(obj);
            }
            
        }
    }
}