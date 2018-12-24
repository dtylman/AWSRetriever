using Amazon;
using Amazon.SNS;
using Amazon.SNS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SNSListEndpointsByPlatformApplicationOperation : Operation
    {
        public override string Name => "ListEndpointsByPlatformApplication";

        public override string Description => "Lists the endpoints and endpoint attributes for devices in a supported push notification service, such as GCM and APNS. The results for ListEndpointsByPlatformApplication are paginated and return a limited list of endpoints, up to 100. If additional records are available after the first page results, then a NextToken string will be returned. To receive the next page, you call ListEndpointsByPlatformApplication again using the NextToken string received from the previous call. When there are no more records to return, NextToken will be null. For more information, see Using Amazon SNS Mobile Push Notifications.  This action is throttled at 30 transactions per second (TPS).";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SNS";

        public override string ServiceID => "SNS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSNSClient client = new AmazonSNSClient(creds, region);
            ListEndpointsByPlatformApplicationResponse resp = new ListEndpointsByPlatformApplicationResponse();
            do
            {
                ListEndpointsByPlatformApplicationInput req = new ListEndpointsByPlatformApplicationInput
                {
                    NextToken = resp.NextToken,
                    &lt;nil&gt; = maxItems
                };
                resp = client.ListEndpointsByPlatformApplication(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Endpoints)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}