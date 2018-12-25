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
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "CloudWatch";

        public override string ServiceID => "CloudWatch";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudWatchClient client = new AmazonCloudWatchClient(creds, region);
            Response resp = new Response();
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