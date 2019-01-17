using Amazon;
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;
using Amazon.Runtime;

namespace CloudOps.AutoScaling
{
    public class DescribeAutoScalingGroupsOperation : Operation
    {
        public override string Name => "DescribeAutoScalingGroups";

        public override string Description => "Describes one or more Auto Scaling groups.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AutoScaling";

        public override string ServiceID => "Auto Scaling";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAutoScalingConfig config = new AmazonAutoScalingConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonAutoScalingClient client = new AmazonAutoScalingClient(creds, config);
            
            DescribeAutoScalingGroupsResponse resp = new DescribeAutoScalingGroupsResponse();
            do
            {
                DescribeAutoScalingGroupsRequest req = new DescribeAutoScalingGroupsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeAutoScalingGroups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.AutoScalingGroups)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}