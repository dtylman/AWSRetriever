using Amazon;
using Amazon.IoTAnalytics;
using Amazon.IoTAnalytics.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IoTAnalyticsListChannelsOperation : Operation
    {
        public override string Name => "ListChannels";

        public override string Description => "Retrieves a list of channels.";
 
        public override string RequestURI => "/channels";

        public override string Method => "GET";

        public override string ServiceName => "IoTAnalytics";

        public override string ServiceID => "IoTAnalytics";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIoTAnalyticsClient client = new AmazonIoTAnalyticsClient(creds, region);
            ListChannelsResponse resp = new ListChannelsResponse();
            do
            {
                ListChannelsRequest req = new ListChannelsRequest
                {
                    nextToken = resp.nextToken
                    ,
                    maxResults = maxItems
                                        
                };

                resp = client.ListChannels(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.channelSummaries)
                {
                    AddObject(obj);
                }
                
                foreach (var obj in resp.nextToken)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}