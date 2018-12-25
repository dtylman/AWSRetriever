using Amazon;
using Amazon.LexModelBuildingService;
using Amazon.LexModelBuildingService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class LexModelBuildingServiceGetBotAliasesOperation : Operation
    {
        public override string Name => "GetBotAliases";

        public override string Description => "Returns a list of aliases for a specified Amazon Lex bot. This operation requires permissions for the lex:GetBotAliases action.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "LexModelBuildingService";

        public override string ServiceID => "Lex Model Building Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonLexModelBuildingServiceClient client = new AmazonLexModelBuildingServiceClient(creds, region);
            Response resp = new Response();
            do
            {
                GetBotAliasesRequest req = new GetBotAliasesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetBotAliases(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}