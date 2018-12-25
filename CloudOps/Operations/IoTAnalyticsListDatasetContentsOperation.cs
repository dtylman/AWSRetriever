using Amazon;
using Amazon.IoTAnalytics;
using Amazon.IoTAnalytics.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IoTAnalyticsListDatasetContentsOperation : Operation
    {
        public override string Name => "ListDatasetContents";

        public override string Description => "Lists information about data set contents that have been created.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "IoTAnalytics";

        public override string ServiceID => "IoTAnalytics";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIoTAnalyticsClient client = new AmazonIoTAnalyticsClient(creds, region);
            Response resp = new Response();
            do
            {
                ListDatasetContentsRequest req = new ListDatasetContentsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListDatasetContents(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}