using Amazon;
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AutoScalingDescribeScalingActivitiesOperation : Operation
    {
        public override string Name => "DescribeScalingActivities";

        public override string Description => "Describes one or more scaling activities for the specified Auto Scaling group.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AutoScaling";

        public override string ServiceID => "Auto Scaling";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAutoScalingClient client = new AmazonAutoScalingClient(creds, region);
            ActivitiesType resp = new ActivitiesType();
            do
            {
                DescribeScalingActivitiesType req = new DescribeScalingActivitiesType
                {
                    NextToken = resp.NextToken,
                    MaxRecords = maxItems
                };
                resp = client.DescribeScalingActivities(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Activities)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}