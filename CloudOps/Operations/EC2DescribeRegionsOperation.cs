using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class EC2DescribeRegionsOperation : Operation
    {
        public override string Name => "DescribeRegions";

        public override string Description => "Describes one or more regions that are currently available to you. For a list of the regions supported by Amazon EC2, see Regions and Endpoints.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribeRegionsResult resp = new DescribeRegionsResult();
            do
            {
                DescribeRegionsRequest req = new DescribeRegionsRequest
                {
                    &lt;nil&gt; = resp.&lt;nil&gt;
                                        
                };

                resp = client.DescribeRegions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Regions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.&lt;nil&gt;));
        }
    }
}