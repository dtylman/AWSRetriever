using Amazon;
using Amazon.SNS;
using Amazon.SNS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SNSListPlatformApplicationsOperation : Operation
    {
        public override string Name => "ListPlatformApplications";

        public override string Description => "Lists the platform application objects for the supported push notification services, such as APNS and GCM. The results for ListPlatformApplications are paginated and return a limited list of applications, up to 100. If additional records are available after the first page results, then a NextToken string will be returned. To receive the next page, you call ListPlatformApplications using the NextToken string received from the previous call. When there are no more records to return, NextToken will be null. For more information, see Using Amazon SNS Mobile Push Notifications.  This action is throttled at 15 transactions per second (TPS).";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SNS";

        public override string ServiceID => "SNS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSNSClient client = new AmazonSNSClient(creds, region);
            ListPlatformApplicationsResponse resp = new ListPlatformApplicationsResponse();
            do
            {
                ListPlatformApplicationsInput req = new ListPlatformApplicationsInput
                {
                    NextToken = resp.NextToken,
                    &lt;nil&gt; = maxItems
                };
                resp = client.ListPlatformApplications(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.PlatformApplications)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}