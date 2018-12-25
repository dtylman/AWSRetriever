using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class EC2DescribeDhcpOptionsOperation : Operation
    {
        public override string Name => "DescribeDhcpOptions";

        public override string Description => "Describes one or more of your DHCP options sets. For more information, see DHCP Options Sets in the Amazon Virtual Private Cloud User Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribeDhcpOptionsResult resp = new DescribeDhcpOptionsResult();
            DescribeDhcpOptionsRequest req = new DescribeDhcpOptionsRequest
            {                    
                                    
            };
            resp = client.DescribeDhcpOptions(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.DhcpOptions)
            {
                AddObject(obj);
            }
            
        }
    }
}