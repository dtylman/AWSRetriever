using Amazon;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using Amazon.Runtime;

namespace CloudOps.CloudWatch
{
    public class DescribeAlarmsOperation : Operation
    {
        public override string Name => "DescribeAlarms";

        public override string Description => "Retrieves the specified alarms. If no alarms are specified, all alarms are returned. Alarms can be retrieved by using only a prefix for the alarm name, the alarm state, or a prefix for any action.";
 
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
            
            DescribeAlarmsResponse resp = new DescribeAlarmsResponse();
            do
            {
                DescribeAlarmsRequest req = new DescribeAlarmsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeAlarms(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.MetricAlarms)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}