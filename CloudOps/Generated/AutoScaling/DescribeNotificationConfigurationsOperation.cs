using Amazon;
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;
using Amazon.Runtime;

namespace CloudOps.AutoScaling
{
    public class DescribeNotificationConfigurationsOperation : Operation
    {
        public override string Name => "DescribeNotificationConfigurations";

        public override string Description => "Describes the notification actions associated with the specified Auto Scaling group.";
 
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
            
            DescribeNotificationConfigurationsResponse resp = new DescribeNotificationConfigurationsResponse();
            do
            {
                DescribeNotificationConfigurationsRequest req = new DescribeNotificationConfigurationsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeNotificationConfigurations(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.NotificationConfigurations)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}