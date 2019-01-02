using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;

namespace CloudOps.DynamoDB
{
    public class QueryOperation : Operation
    {
        public override string Name => "Query";

        public override string Description => "Gets the values of one or more items and its attributes by primary key (composite primary key, only). Narrow the scope of the query using comparison operators on the RangeKeyValue of the composite key. Use the ScanIndexForward parameter to get results in forward or reverse order by range key.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DynamoDB";

        public override string ServiceID => "DynamoDB";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(creds, region);
            QueryResponse resp = new QueryResponse();
            QueryRequest req = new QueryRequest
            {
                ExclusiveStartKey = resp.LastEvaluatedKey
                ,
                Limit = maxItems

            };

            resp = client.Query(req);
            CheckError(resp.HttpStatusCode, "200");

            foreach (var obj in resp.Items)
            {
                AddObject(obj);
            }
                   
        }
    }
}