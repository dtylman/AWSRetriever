using Amazon;
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudWatchLogsDescribeLogGroupsOperation : Operation
    {
        public override string Name => "DescribeLogGroups";

        public override string Description => "Lists the specified log groups. You can list all your log groups or filter the results by prefix. The results are ASCII-sorted by log group name.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudWatchLogs";

        public override string ServiceID => "CloudWatch Logs";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudWatchLogsClient client = new AmazonCloudWatchLogsClient(creds, region);
            DescribeLogGroupsResponse resp = new DescribeLogGroupsResponse();
            do
            {
                DescribeLogGroupsRequest req = new DescribeLogGroupsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.DescribeLogGroups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.LogGroups)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}