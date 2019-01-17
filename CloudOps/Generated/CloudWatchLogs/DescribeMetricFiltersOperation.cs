using Amazon;
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;
using Amazon.Runtime;

namespace CloudOps.CloudWatchLogs
{
    public class DescribeMetricFiltersOperation : Operation
    {
        public override string Name => "DescribeMetricFilters";

        public override string Description => "Lists the specified metric filters. You can list all the metric filters or filter the results by log name, prefix, metric name, or metric namespace. The results are ASCII-sorted by filter name.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudWatchLogs";

        public override string ServiceID => "CloudWatch Logs";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudWatchLogsConfig config = new AmazonCloudWatchLogsConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonCloudWatchLogsClient client = new AmazonCloudWatchLogsClient(creds, config);
            
            DescribeMetricFiltersResponse resp = new DescribeMetricFiltersResponse();
            do
            {
                DescribeMetricFiltersRequest req = new DescribeMetricFiltersRequest
                {
                    NextToken = resp.NextToken
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.DescribeMetricFilters(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.MetricFilters)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}