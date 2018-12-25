using Amazon;
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudWatchLogsDescribeMetricFiltersOperation : Operation
    {
        public override string Name => "DescribeMetricFilters";

        public override string Description => "Lists the specified metric filters. You can list all the metric filters or filter the results by log name, prefix, metric name, or metric namespace. The results are ASCII-sorted by filter name.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudWatchLogs";

        public override string ServiceID => "CloudWatch Logs";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudWatchLogsClient client = new AmazonCloudWatchLogsClient(creds, region);
            DescribeMetricFiltersResponse resp = new DescribeMetricFiltersResponse();
            do
            {
                DescribeMetricFiltersRequest req = new DescribeMetricFiltersRequest
                {
                    nextToken = resp.nextToken
                    ,
                    limit = maxItems
                                        
                };

                resp = client.DescribeMetricFilters(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.metricFilters)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}