using Amazon;
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;
using Amazon.Runtime;

namespace CloudOps.AutoScaling
{
    public class DescribeScalingActivitiesOperation : Operation
    {
        public override string Name => "DescribeScalingActivities";

        public override string Description => "Describes one or more scaling activities for the specified Auto Scaling group.";
 
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
            
            DescribeScalingActivitiesResponse resp = new DescribeScalingActivitiesResponse();
            do
            {
                DescribeScalingActivitiesRequest req = new DescribeScalingActivitiesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeScalingActivities(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Activities)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}