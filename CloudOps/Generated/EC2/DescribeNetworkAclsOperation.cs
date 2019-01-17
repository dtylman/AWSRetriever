using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.EC2
{
    public class DescribeNetworkAclsOperation : Operation
    {
        public override string Name => "DescribeNetworkAcls";

        public override string Description => "Describes one or more of your network ACLs. For more information, see Network ACLs in the Amazon Virtual Private Cloud User Guide.";
 
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
            
            DescribeNetworkAclsResponse resp = new DescribeNetworkAclsResponse();
            DescribeNetworkAclsRequest req = new DescribeNetworkAclsRequest
            {                    
                                    
            };
            resp = client.DescribeNetworkAcls(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.NetworkAcls)
            {
                AddObject(obj);
            }
            
        }
    }
}