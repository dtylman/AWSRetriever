using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Amazon.Runtime;

namespace CloudOps.SimpleNotificationService
{
    public class ListTopicsOperation : Operation
    {
        public override string Name => "ListTopics";

        public override string Description => "Returns a list of the requester&#39;s topics. Each call returns a limited list of topics, up to 100. If there are more topics, a NextToken is also returned. Use the NextToken parameter in a new ListTopics call to get further results. This action is throttled at 30 transactions per second (TPS).";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SimpleNotificationService";

        public override string ServiceID => "SNS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSimpleNotificationServiceClient client = new AmazonSimpleNotificationServiceClient(creds, region);
            ListTopicsResponse resp = new ListTopicsResponse();
            do
            {
                ListTopicsRequest req = new ListTopicsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListTopics(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Topics)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}