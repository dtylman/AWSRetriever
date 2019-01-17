using Amazon;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using Amazon.Runtime;

namespace CloudOps.CloudWatch
{
    public class DescribeAlarmHistoryOperation : Operation
    {
        public override string Name => "DescribeAlarmHistory";

        public override string Description => "Retrieves the history for the specified alarm. You can filter the results by date range or item type. If an alarm name is not specified, the histories for all alarms are returned. CloudWatch retains the history of an alarm even if you delete the alarm.";
 
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
            
            DescribeAlarmHistoryResponse resp = new DescribeAlarmHistoryResponse();
            do
            {
                DescribeAlarmHistoryRequest req = new DescribeAlarmHistoryRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeAlarmHistory(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.AlarmHistoryItems)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}