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
                GetLogEventsRequest req = new GetLogEventsRequest
                {
                    NextToken = resp.NextForwardToken
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.GetLogEvents(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Events)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextForwardToken));
        }
    }
}