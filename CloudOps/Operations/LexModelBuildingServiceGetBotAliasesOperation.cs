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
 
        public override string RequestURI => "/bots/{botName}/aliases/";

        public override string Method => "GET";

        public override string ServiceName => "LexModelBuildingService";

        public override string ServiceID => "Lex Model Building Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonLexModelBuildingServiceClient client = new AmazonLexModelBuildingServiceClient(creds, region);
            GetBotAliasesResponse resp = new GetBotAliasesResponse();
            do
            {
                GetBotAliasesRequest req = new GetBotAliasesRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.GetBotAliases(req);
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}