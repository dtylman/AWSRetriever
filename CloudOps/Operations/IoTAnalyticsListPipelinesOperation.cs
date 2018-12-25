using Amazon;
using Amazon.IoTAnalytics;
using Amazon.IoTAnalytics.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IoTAnalyticsListPipelinesOperation : Operation
    {
        public override string Name => "ListPipelines";

        public override string Description => "Retrieves a list of pipelines.";
 
        public override string RequestURI => "/pipelines";

        public override string Method => "GET";

        public override string ServiceName => "IoTAnalytics";

        public override string ServiceID => "IoTAnalytics";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIoTAnalyticsClient client = new AmazonIoTAnalyticsClient(creds, region);
            ListPipelinesResponse resp = new ListPipelinesResponse();
            do
            {
                ListPipelinesRequest req = new ListPipelinesRequest
                {
                    nextToken = resp.nextToken
                    ,
                    maxResults = maxItems
                                        
                };

                resp = client.ListPipelines(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}