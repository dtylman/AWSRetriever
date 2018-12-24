using Amazon;
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudWatchLogsDescribeDestinationsOperation : Operation
    {
        public override string Name => "DescribeDestinations";

        public override string Description => "Lists all your destinations. The results are ASCII-sorted by destination name.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudWatchLogs";

        public override string ServiceID => "CloudWatch Logs";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudWatchLogsClient client = new AmazonCloudWatchLogsClient(creds, region);
            DescribeDestinationsResponse resp = new DescribeDestinationsResponse();
            do
            {
                DescribeDestinationsRequest req = new DescribeDestinationsRequest
                {
                    nextToken = resp.nextToken,
                    limit = maxItems
                };
                resp = client.DescribeDestinations(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.destinations)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}