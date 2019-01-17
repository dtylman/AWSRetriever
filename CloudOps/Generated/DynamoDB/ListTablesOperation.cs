using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;

namespace CloudOps.DynamoDB
{
    public class ListTablesOperation : Operation
    {
        public override string Name => "ListTables";

        public override string Description => "Returns an array of table names associated with the current account and endpoint. The output from ListTables is paginated, with each page returning a maximum of 100 table names.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DynamoDB";

        public override string ServiceID => "DynamoDB";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDynamoDBConfig config = new AmazonDynamoDBConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(creds, config);
            
            ListTablesResponse resp = new ListTablesResponse();
            do
            {
                ListTablesRequest req = new ListTablesRequest
                {
                    ExclusiveStartTableName = resp.LastEvaluatedTableName
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.ListTables(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.TableNames)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.LastEvaluatedTableName));
        }
    }
}