using Amazon;
using Amazon.IoTAnalytics;
using Amazon.IoTAnalytics.Model;
using Amazon.Runtime;

namespace CloudOps.IoTAnalytics
{
    public class ListPipelinesOperation : Operation
    {
        public override string Name => "ListPipelines";

        public override string Description => "Retrieves a list of pipelines.";
 
        public override string RequestURI => "/pipelines";

        public override string Method => "GET";

        public override string ServiceName => "IoTAnalytics";

        public override string ServiceID => "IoTAnalytics";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIoTAnalyticsConfig config = new AmazonIoTAnalyticsConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonIoTAnalyticsClient client = new AmazonIoTAnalyticsClient(creds, config);
            
            ListPipelinesResponse resp = new ListPipelinesResponse();
            do
            {
                ListPipelinesRequest req = new ListPipelinesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListPipelines(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.PipelineSummaries)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}