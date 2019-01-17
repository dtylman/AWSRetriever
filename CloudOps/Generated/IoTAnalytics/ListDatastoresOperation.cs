using Amazon;
using Amazon.IoTAnalytics;
using Amazon.IoTAnalytics.Model;
using Amazon.Runtime;

namespace CloudOps.IoTAnalytics
{
    public class ListDatastoresOperation : Operation
    {
        public override string Name => "ListDatastores";

        public override string Description => "Retrieves a list of data stores.";
 
        public override string RequestURI => "/datastores";

        public override string Method => "GET";

        public override string ServiceName => "IoTAnalytics";

        public override string ServiceID => "IoTAnalytics";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIoTAnalyticsConfig config = new AmazonIoTAnalyticsConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonIoTAnalyticsClient client = new AmazonIoTAnalyticsClient(creds, config);
            
            ListDatastoresResponse resp = new ListDatastoresResponse();
            do
            {
                ListDatastoresRequest req = new ListDatastoresRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListDatastores(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DatastoreSummaries)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}