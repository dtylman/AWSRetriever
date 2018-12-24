using Amazon;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudWatchDescribeAlarmsOperation : Operation
    {
        public override string Name => "DescribeAlarms";

        public override string Description => "Retrieves the specified alarms. If no alarms are specified, all alarms are returned. Alarms can be retrieved by using only a prefix for the alarm name, the alarm state, or a prefix for any action.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudWatch";

        public override string ServiceID => "CloudWatch";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudWatchClient client = new AmazonCloudWatchClient(creds, region);
            DescribeAlarmsOutput resp = new DescribeAlarmsOutput();
            do
            {
                DescribeAlarmsInput req = new DescribeAlarmsInput
                {
                    NextToken = resp.NextToken,
                    MaxRecords = maxItems
                };
                resp = client.DescribeAlarms(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.MetricAlarms)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}