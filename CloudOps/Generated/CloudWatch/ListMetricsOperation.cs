using Amazon;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using Amazon.Runtime;

namespace CloudOps.CloudWatch
{
    public class ListMetricsOperation : Operation
    {
        public override string Name => "ListMetrics";

        public override string Description => "List the specified metrics. You can use the returned metrics with GetMetricData or GetMetricStatistics to obtain statistical data. Up to 500 results are returned for any one call. To retrieve additional results, use the returned token with subsequent calls. After you create a metric, allow up to fifteen minutes before the metric appears. Statistics about the metric, however, are available sooner using GetMetricData or GetMetricStatistics.";
 
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
            
            ListMetricsResponse resp = new ListMetricsResponse();
            do
            {
                ListMetricsRequest req = new ListMetricsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListMetrics(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Metrics)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}