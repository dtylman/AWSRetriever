using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RDSDescribeEventSubscriptionsOperation : Operation
    {
        public override string Name => "DescribeEventSubscriptions";

        public override string Description => "Lists all the subscription descriptions for a customer account. The description for a subscription includes SubscriptionName, SNSTopicARN, CustomerID, SourceType, SourceID, CreationTime, and Status. If you specify a SubscriptionName, lists the description for that subscription.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            EventSubscriptionsMessageResponse resp = new EventSubscriptionsMessageResponse();
            do
            {
                DescribeEventSubscriptionsMessageRequest req = new DescribeEventSubscriptionsMessageRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeEventSubscriptions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.EventSubscriptionsList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}