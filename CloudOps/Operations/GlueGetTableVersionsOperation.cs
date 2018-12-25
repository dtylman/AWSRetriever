using Amazon;
using Amazon.Glue;
using Amazon.Glue.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class GlueGetTableVersionsOperation : Operation
    {
        public override string Name => "GetTableVersions";

        public override string Description => "Retrieves a list of strings that identify available versions of a specified table.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "Glue";

        public override string ServiceID => "Glue";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGlueClient client = new AmazonGlueClient(creds, region);
            Response resp = new Response();
            do
            {
                GetTableVersionsRequest req = new GetTableVersionsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetTableVersions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}