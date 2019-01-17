using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Amazon.Runtime;

namespace CloudOps.SimpleNotificationService
{
    public class ListPlatformApplicationsOperation : Operation
    {
        public override string Name => "ListPlatformApplications";

        public override string Description => "Lists the platform application objects for the supported push notification services, such as APNS and GCM. The results for ListPlatformApplications are paginated and return a limited list of applications, up to 100. If additional records are available after the first page results, then a NextToken string will be returned. To receive the next page, you call ListPlatformApplications using the NextToken string received from the previous call. When there are no more records to return, NextToken will be null. For more information, see Using Amazon SNS Mobile Push Notifications.  This action is throttled at 15 transactions per second (TPS).";
 
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
            
            ListPlatformApplicationsResponse resp = new ListPlatformApplicationsResponse();
            do
            {
                ListPlatformApplicationsRequest req = new ListPlatformApplicationsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListPlatformApplications(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.PlatformApplications)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}