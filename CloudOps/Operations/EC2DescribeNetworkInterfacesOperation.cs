using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class EC2DescribeNetworkInterfacesOperation : Operation
    {
        public override string Name => "DescribeNetworkInterfaces";

        public override string Description => "Describes one or more of your network interfaces.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribeNetworkInterfacesResult resp = new DescribeNetworkInterfacesResult();
            do
            {
                DescribeNetworkInterfacesRequest req = new DescribeNetworkInterfacesRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.DescribeNetworkInterfaces(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.NetworkInterfaces)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}