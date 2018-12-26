using Amazon;
using Amazon.Glue;
using Amazon.Glue.Model;
using Amazon.Runtime;

namespace CloudOps.Glue
{
    public class GetDatabasesOperation : Operation
    {
        public override string Name => "GetDatabases";

        public override string Description => "Retrieves all Databases defined in a given Data Catalog.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Glue";

        public override string ServiceID => "Glue";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGlueClient client = new AmazonGlueClient(creds, region);
            GetDatabasesResponse resp = new GetDatabasesResponse();
            do
            {
                GetDatabasesRequest req = new GetDatabasesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetDatabases(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DatabaseList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}