using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class EC2DescribeAddressesOperation : Operation
    {
        public override string Name => "DescribeAddresses";

        public override string Description => "Describes one or more of your Elastic IP addresses. An Elastic IP address is for use in either the EC2-Classic platform or in a VPC. For more information, see Elastic IP Addresses in the Amazon Elastic Compute Cloud User Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribeAddressesResult resp = new DescribeAddressesResult();
            DescribeAddressesRequest req = new DescribeAddressesRequest
            {                    
                                    
            };
            resp = client.DescribeAddresses(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.Addresses)
            {
                AddObject(obj);
            }
            
        }
    }
}