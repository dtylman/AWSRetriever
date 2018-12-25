using Amazon;
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DirectConnectDescribeInterconnectsOperation : Operation
    {
        public override string Name => "DescribeInterconnects";

        public override string Description => "Lists the interconnects owned by the AWS account or only the specified interconnect.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DirectConnect";

        public override string ServiceID => "Direct Connect";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDirectConnectClient client = new AmazonDirectConnectClient(creds, region);
            Interconnects resp = new Interconnects();
            do
            {
                DescribeInterconnectsRequest req = new DescribeInterconnectsRequest
                {
                    &lt;nil&gt; = resp.&lt;nil&gt;
                                        
                };

                resp = client.DescribeInterconnects(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.interconnects)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.&lt;nil&gt;));
        }
    }
}