using Amazon;
using Amazon.IoTAnalytics;
using Amazon.IoTAnalytics.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IoTAnalyticsListDatastoresOperation : Operation
    {
        public override string Name => "ListDatastores";

        public override string Description => "Retrieves a list of data stores.";
 
        public override string RequestURI => "/datastores";

        public override string Method => "GET";

        public override string ServiceName => "IoTAnalytics";

        public override string ServiceID => "IoTAnalytics";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIoTAnalyticsClient client = new AmazonIoTAnalyticsClient(creds, region);
            ListDatastoresResponse resp = new ListDatastoresResponse();
            do
            {
                ListDatastoresRequest req = new ListDatastoresRequest
                {
                    nextToken = resp.nextToken
                    ,
                    maxResults = maxItems
                                        
                };

                resp = client.ListDatastores(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.datastoreSummaries)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}