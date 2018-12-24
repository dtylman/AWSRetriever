using Amazon;
using Amazon.SNS;
using Amazon.SNS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SNSListSubscriptionsByTopicOperation : Operation
    {
        public override string Name => "ListSubscriptionsByTopic";

        public override string Description => "Returns a list of the subscriptions to a specific topic. Each call returns a limited list of subscriptions, up to 100. If there are more subscriptions, a NextToken is also returned. Use the NextToken parameter in a new ListSubscriptionsByTopic call to get further results. This action is throttled at 30 transactions per second (TPS).";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SNS";

        public override string ServiceID => "SNS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSNSClient client = new AmazonSNSClient(creds, region);
            ListSubscriptionsByTopicResponse resp = new ListSubscriptionsByTopicResponse();
            do
            {
                ListSubscriptionsByTopicInput req = new ListSubscriptionsByTopicInput
                {
                    NextToken = resp.NextToken,
                    &lt;nil&gt; = maxItems
                };
                resp = client.ListSubscriptionsByTopic(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Subscriptions)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}