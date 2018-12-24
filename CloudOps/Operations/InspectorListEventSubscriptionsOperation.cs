using Amazon;
using Amazon.Inspector;
using Amazon.Inspector.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class InspectorListEventSubscriptionsOperation : Operation
    {
        public override string Name => "ListEventSubscriptions";

        public override string Description => "Lists all the event subscriptions for the assessment template that is specified by the ARN of the assessment template. For more information, see SubscribeToEvent and UnsubscribeFromEvent.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Inspector";

        public override string ServiceID => "Inspector";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonInspectorClient client = new AmazonInspectorClient(creds, region);
            ListEventSubscriptionsResponse resp = new ListEventSubscriptionsResponse();
            do
            {
                ListEventSubscriptionsRequest req = new ListEventSubscriptionsRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.ListEventSubscriptions(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}