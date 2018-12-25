using Amazon;
using Amazon.DynamoDB;
using Amazon.DynamoDB.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DynamoDBBatchGetItemOperation : Operation
    {
        public override string Name => "BatchGetItem";

        public override string Description => "The BatchGetItem operation returns the attributes of one or more items from one or more tables. You identify requested items by primary key. A single operation can retrieve up to 16 MB of data, which can contain as many as 100 items. BatchGetItem will return a partial result if the response size limit is exceeded, the table&#39;s provisioned throughput is exceeded, or an internal processing failure occurs. If a partial result is returned, the operation returns a value for UnprocessedKeys. You can use this value to retry the operation starting with the next item to get.  If you request more than 100 items BatchGetItem will return a ValidationException with the message &#34;Too many items requested for the BatchGetItem call&#34;.  For example, if you ask to retrieve 100 items, but each individual item is 300 KB in size, the system returns 52 items (so as not to exceed the 16 MB limit). It also returns an appropriate UnprocessedKeys value so you can get the next page of results. If desired, your application can include its own logic to assemble the pages of results into one data set. If none of the items can be processed due to insufficient provisioned throughput on all of the tables in the request, then BatchGetItem will return a ProvisionedThroughputExceededException. If at least one of the items is successfully processed, then BatchGetItem completes successfully, while returning the keys of the unread items in UnprocessedKeys.  If DynamoDB returns any unprocessed items, you should retry the batch operation on those items. However, we strongly recommend that you use an exponential backoff algorithm. If you retry the batch operation immediately, the underlying read or write requests can still fail due to throttling on the individual tables. If you delay the batch operation using exponential backoff, the individual requests in the batch are much more likely to succeed. For more information, see Batch Operations and Error Handling in the Amazon DynamoDB Developer Guide.  By default, BatchGetItem performs eventually consistent reads on every table in the request. If you want strongly consistent reads instead, you can set ConsistentRead to true for any or all tables. In order to minimize response latency, BatchGetItem retrieves items in parallel. When designing your application, keep in mind that DynamoDB does not return items in any particular order. To help parse the response by item, include the primary key values for the items in your request in the ProjectionExpression parameter. If a requested item does not exist, it is not returned in the result. Requests for nonexistent items consume the minimum read capacity units according to the type of read. For more information, see Capacity Units Calculations in the Amazon DynamoDB Developer Guide.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "DynamoDB";

        public override string ServiceID => "DynamoDB";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(creds, region);
            Response resp = new Response();
            do
            {
                BatchGetItemRequest req = new BatchGetItemRequest
                {
                    RequestItems = resp.UnprocessedKeys
                                        
                };

                resp = client.BatchGetItem(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.UnprocessedKeys));
        }
    }
}