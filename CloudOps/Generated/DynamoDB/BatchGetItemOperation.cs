using Amazon;
using Amazon.DynamoDB;
using Amazon.DynamoDB.Model;
using Amazon.Runtime;

namespace CloudOps.DynamoDB
{
    public class BatchGetItemOperation : Operation
    {
        public override string Name => "BatchGetItem";

        public override string Description => "Retrieves the attributes for multiple items from multiple tables using their primary keys. The maximum number of item attributes that can be retrieved for a single operation is 100. Also, the number of items retrieved is constrained by a 1 MB the size limit. If the response size limit is exceeded or a partial result is returned due to an internal processing failure, Amazon DynamoDB returns an UnprocessedKeys value so you can retry the operation starting with the next item to get. Amazon DynamoDB automatically adjusts the number of items returned per page to enforce this limit. For example, even if you ask to retrieve 100 items, but each individual item is 50k in size, the system returns 20 items and an appropriate UnprocessedKeys value so you can get the next page of results. If necessary, your application needs its own logic to assemble the pages of results into one set.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DynamoDB";

        public override string ServiceID => "DynamoDB";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(creds, region);
            BatchGetItemResponse resp = new BatchGetItemResponse();
            do
            {
                BatchGetItemRequest req = new BatchGetItemRequest
                {
                    RequestItems = resp.UnprocessedKeys
                                        
                };

                resp = client.BatchGetItem(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Responses)
                {
                    AddObject(obj);
                }
                
                foreach (var obj in resp.UnprocessedKeys)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.UnprocessedKeys));
        }
    }
}