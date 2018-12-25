using Amazon;
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DatabaseMigrationServiceDescribeEventSubscriptionsOperation : Operation
    {
        public override string Name => "DescribeEventSubscriptions";

        public override string Description => "Lists all the event subscriptions for a customer account. The description of a subscription includes SubscriptionName, SNSTopicARN, CustomerID, SourceType, SourceID, CreationTime, and Status.  If you specify SubscriptionName, this action lists the description for that subscription.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DatabaseMigrationService";

        public override string ServiceID => "Database Migration Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDatabaseMigrationServiceClient client = new AmazonDatabaseMigrationServiceClient(creds, region);
            DescribeEventSubscriptionsResponse resp = new DescribeEventSubscriptionsResponse();
            do
            {
                DescribeEventSubscriptionsMessage req = new DescribeEventSubscriptionsMessage
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeEventSubscriptions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Marker)
                {
                    AddObject(obj);
                }
                
                foreach (var obj in resp.EventSubscriptionsList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}