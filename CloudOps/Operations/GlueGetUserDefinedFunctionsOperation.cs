using Amazon;
using Amazon.Glue;
using Amazon.Glue.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class GlueGetUserDefinedFunctionsOperation : Operation
    {
        public override string Name => "GetUserDefinedFunctions";

        public override string Description => "Retrieves a multiple function definitions from the Data Catalog.";
 
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
                GetUserDefinedFunctionsRequest req = new GetUserDefinedFunctionsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetUserDefinedFunctions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}