using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class EC2DescribeSubnetsOperation : Operation
    {
        public override string Name => "DescribeSubnets";

        public override string Description => "Describes one or more of your subnets. For more information, see Your VPC and Subnets in the Amazon Virtual Private Cloud User Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribeSubnetsResultResponse resp = new DescribeSubnetsResultResponse();
            DescribeSubnetsRequest req = new DescribeSubnetsRequest
            {                    
                                    
            };
            resp = client.DescribeSubnets(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.Subnets)
            {
                AddObject(obj);
            }
            
        }
    }
}