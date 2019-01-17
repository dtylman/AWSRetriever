using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.EC2
{
    public class DescribeInternetGatewaysOperation : Operation
    {
        public override string Name => "DescribeInternetGateways";

        public override string Description => "Describes one or more of your internet gateways.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Config config = new AmazonEC2Config();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonEC2Client client = new AmazonEC2Client(creds, config);
            
            DescribeInternetGatewaysResponse resp = new DescribeInternetGatewaysResponse();
            DescribeInternetGatewaysRequest req = new DescribeInternetGatewaysRequest
            {                    
                                    
            };
            resp = client.DescribeInternetGateways(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.InternetGateways)
            {
                AddObject(obj);
            }
            
        }
    }
}