using Amazon;
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudWatchLogsDescribeLogStreamsOperation : Operation
    {
        public override string Name => "DescribeLogStreams";

        public override string Description => "Lists the log streams for the specified log group. You can list all the log streams or filter the results by prefix. You can also control how the results are ordered. This operation has a limit of five transactions per second, after which transactions are throttled.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "CloudWatchLogs";

        public override string ServiceID => "CloudWatch Logs";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudWatchLogsClient client = new AmazonCloudWatchLogsClient(creds, region);
            Response resp = new Response();
            do
            {
                DescribeLogStreamsRequest req = new DescribeLogStreamsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.DescribeLogStreams(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.LogStreams)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}