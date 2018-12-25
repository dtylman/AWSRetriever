using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SimpleNotificationServiceListSubscriptionsByTopicOperation : Operation
    {
        public override string Name => "ListSubscriptionsByTopic";

        public override string Description => "Returns a list of the subscriptions to a specific topic. Each call returns a limited list of subscriptions, up to 100. If there are more subscriptions, a NextToken is also returned. Use the NextToken parameter in a new ListSubscriptionsByTopic call to get further results. This action is throttled at 30 transactions per second (TPS).";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "SimpleNotificationService";

        public override string ServiceID => "SNS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSimpleNotificationServiceClient client = new AmazonSimpleNotificationServiceClient(creds, region);
            Response resp = new Response();
            do
            {
                ListSubscriptionsByTopicRequest req = new ListSubscriptionsByTopicRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListSubscriptionsByTopic(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Subscriptions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}