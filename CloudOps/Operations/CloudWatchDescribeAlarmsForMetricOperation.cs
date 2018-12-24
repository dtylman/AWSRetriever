using Amazon;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudWatchDescribeAlarmsForMetricOperation : Operation
    {
        public override string Name => "DescribeAlarmsForMetric";

        public override string Description => "Retrieves the alarms for the specified metric. To filter the results, specify a statistic, period, or unit.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudWatch";

        public override string ServiceID => "CloudWatch";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudWatchClient client = new AmazonCloudWatchClient(creds, region);
            DescribeAlarmsForMetricOutput resp = new DescribeAlarmsForMetricOutput();
            do
            {
                DescribeAlarmsForMetricInput req = new DescribeAlarmsForMetricInput
                {
                    &lt;nil&gt; = resp.&lt;nil&gt;,
                    &lt;nil&gt; = maxItems
                };
                resp = client.DescribeAlarmsForMetric(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.MetricAlarms)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.&lt;nil&gt;));
        }
    }
}