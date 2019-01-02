using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;

namespace CloudOps.DynamoDB
{
    public class ScanOperation : Operation
    {
        public override string Name => "Scan";

        public override string Description => "Retrieves one or more items and its attributes by performing a full scan of a table. Provide a ScanFilter to get more specific results.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DynamoDB";

        public override string ServiceID => "DynamoDB";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(creds, region);
            ScanResponse resp = new ScanResponse();
            ScanRequest req = new ScanRequest
            {
                ExclusiveStartKey = resp.LastEvaluatedKey
                ,
                Limit = maxItems

            };

            resp = client.Scan(req);
            CheckError(resp.HttpStatusCode, "200");

            foreach (var obj in resp.Items)
            {
                AddObject(obj);
            }


        }
    }
}