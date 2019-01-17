using Amazon;
using Amazon.Glue;
using Amazon.Glue.Model;
using Amazon.Runtime;

namespace CloudOps.Glue
{
    public class GetConnectionsOperation : Operation
    {
        public override string Name => "GetConnections";

        public override string Description => "Retrieves a list of connection definitions from the Data Catalog.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Glue";

        public override string ServiceID => "Glue";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGlueConfig config = new AmazonGlueConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonGlueClient client = new AmazonGlueClient(creds, config);
            
            GetConnectionsResponse resp = new GetConnectionsResponse();
            do
            {
                GetConnectionsRequest req = new GetConnectionsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetConnections(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ConnectionList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}