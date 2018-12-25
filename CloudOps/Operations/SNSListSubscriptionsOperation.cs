using Amazon;
using Amazon.SNS;
using Amazon.SNS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SNSListSubscriptionsOperation : Operation
    {
        public override string Name => "ListSubscriptions";

        public override string Description => "Returns a list of the requester&#39;s subscriptions. Each call returns a limited list of subscriptions, up to 100. If there are more subscriptions, a NextToken is also returned. Use the NextToken parameter in a new ListSubscriptions call to get further results. This action is throttled at 30 transactions per second (TPS).";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SNS";

        public override string ServiceID => "SNS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSNSClient client = new AmazonSNSClient(creds, region);
            ListSubscriptionsResponse resp = new ListSubscriptionsResponse();
            do
            {
                ListSubscriptionsInput req = new ListSubscriptionsInput
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListSubscriptions(req);
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