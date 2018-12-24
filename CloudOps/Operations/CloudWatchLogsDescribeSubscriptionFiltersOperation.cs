using Amazon;
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudWatchLogsDescribeSubscriptionFiltersOperation : Operation
    {
        public override string Name => "DescribeSubscriptionFilters";

        public override string Description => "Lists the subscription filters for the specified log group. You can list all the subscription filters or filter the results by prefix. The results are ASCII-sorted by filter name.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudWatchLogs";

        public override string ServiceID => "CloudWatch Logs";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudWatchLogsClient client = new AmazonCloudWatchLogsClient(creds, region);
            DescribeSubscriptionFiltersResponse resp = new DescribeSubscriptionFiltersResponse();
            do
            {
                DescribeSubscriptionFiltersRequest req = new DescribeSubscriptionFiltersRequest
                {
                    nextToken = resp.nextToken,
                    limit = maxItems
                };
                resp = client.DescribeSubscriptionFilters(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.subscriptionFilters)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}