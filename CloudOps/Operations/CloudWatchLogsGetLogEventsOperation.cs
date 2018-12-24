using Amazon;
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudWatchLogsGetLogEventsOperation : Operation
    {
        public override string Name => "GetLogEvents";

        public override string Description => "Lists log events from the specified log stream. You can list all the log events or filter using a time range. By default, this operation returns as many log events as can fit in a response size of 1MB (up to 10,000 log events). You can get additional log events by specifying one of the tokens in a subsequent call.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudWatchLogs";

        public override string ServiceID => "CloudWatch Logs";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudWatchLogsClient client = new AmazonCloudWatchLogsClient(creds, region);
            GetLogEventsResponse resp = new GetLogEventsResponse();
            do
            {
                GetLogEventsRequest req = new GetLogEventsRequest
                {
                    nextToken = resp.nextForwardToken,
                    limit = maxItems
                };
                resp = client.GetLogEvents(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.events)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextForwardToken));
        }
    }
}