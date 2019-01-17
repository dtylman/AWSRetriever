using Amazon;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using Amazon.Runtime;

namespace CloudOps.CloudWatch
{
    public class DescribeAlarmsForMetricOperation : Operation
    {
        public override string Name => "DescribeAlarmsForMetric";

        public override string Description => "Retrieves the alarms for the specified metric. To filter the results, specify a statistic, period, or unit.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudWatch";

        public override string ServiceID => "CloudWatch";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudWatchConfig config = new AmazonCloudWatchConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonCloudWatchClient client = new AmazonCloudWatchClient(creds, config);
            
            DescribeAlarmsForMetricResponse resp = new DescribeAlarmsForMetricResponse();
            DescribeAlarmsForMetricRequest req = new DescribeAlarmsForMetricRequest
            {                    
                                    
            };
            resp = client.DescribeAlarmsForMetric(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.MetricAlarms)
            {
                AddObject(obj);
            }
            
        }
    }
}