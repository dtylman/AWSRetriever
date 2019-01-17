using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.EC2
{
    public class DescribeKeyPairsOperation : Operation
    {
        public override string Name => "DescribeKeyPairs";

        public override string Description => "Describes one or more of your key pairs. For more information about key pairs, see Key Pairs in the Amazon Elastic Compute Cloud User Guide.";
 
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
            
            DescribeKeyPairsResponse resp = new DescribeKeyPairsResponse();
            DescribeKeyPairsRequest req = new DescribeKeyPairsRequest
            {                    
                                    
            };
            resp = client.DescribeKeyPairs(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.KeyPairs)
            {
                AddObject(obj);
            }
            
        }
    }
}