using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Amazon.Runtime;

namespace CloudOps.SimpleNotificationService
{
    public class ListEndpointsByPlatformApplicationOperation : Operation
    {
        public override string Name => "ListEndpointsByPlatformApplication";

        public override string Description => "Lists the endpoints and endpoint attributes for devices in a supported push notification service, such as GCM and APNS. The results for ListEndpointsByPlatformApplication are paginated and return a limited list of endpoints, up to 100. If additional records are available after the first page results, then a NextToken string will be returned. To receive the next page, you call ListEndpointsByPlatformApplication again using the NextToken string received from the previous call. When there are no more records to return, NextToken will be null. For more information, see Using Amazon SNS Mobile Push Notifications.  This action is throttled at 30 transactions per second (TPS).";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SimpleNotificationService";

        public override string ServiceID => "SNS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSimpleNotificationServiceConfig config = new AmazonSimpleNotificationServiceConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonSimpleNotificationServiceClient client = new AmazonSimpleNotificationServiceClient(creds, config);
            
            ListEndpointsByPlatformApplicationResponse resp = new ListEndpointsByPlatformApplicationResponse();
            do
            {
                ListEndpointsByPlatformApplicationRequest req = new ListEndpointsByPlatformApplicationRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListEndpointsByPlatformApplication(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Endpoints)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}