using Amazon;
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;
using Amazon.Runtime;

namespace CloudOps.AutoScaling
{
    public class DescribeAutoScalingInstancesOperation : Operation
    {
        public override string Name => "DescribeAutoScalingInstances";

        public override string Description => "Describes one or more Auto Scaling instances.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AutoScaling";

        public override string ServiceID => "Auto Scaling";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAutoScalingClient client = new AmazonAutoScalingClient(creds, region);
            DescribeAutoScalingInstancesResponse resp = new DescribeAutoScalingInstancesResponse();
            do
            {
                DescribeAutoScalingInstancesRequest req = new DescribeAutoScalingInstancesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeAutoScalingInstances(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.AutoScalingInstances)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}