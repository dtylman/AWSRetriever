using Amazon;
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AutoScalingDescribeScheduledActionsOperation : Operation
    {
        public override string Name => "DescribeScheduledActions";

        public override string Description => "Describes the actions scheduled for your Auto Scaling group that haven&#39;t run. To describe the actions that have already run, use DescribeScalingActivities.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AutoScaling";

        public override string ServiceID => "Auto Scaling";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAutoScalingClient client = new AmazonAutoScalingClient(creds, region);
            ScheduledActionsTypeResponse resp = new ScheduledActionsTypeResponse();
            do
            {
                DescribeScheduledActionsTypeRequest req = new DescribeScheduledActionsTypeRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeScheduledActions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ScheduledUpdateGroupActions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}