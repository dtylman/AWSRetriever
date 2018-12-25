using Amazon;
using Amazon.LexModelBuildingService;
using Amazon.LexModelBuildingService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class LexModelBuildingServiceGetBotVersionsOperation : Operation
    {
        public override string Name => "GetBotVersions";

        public override string Description => "Gets information about all of the versions of a bot. The GetBotVersions operation returns a BotMetadata object for each version of a bot. For example, if a bot has three numbered versions, the GetBotVersions operation returns four BotMetadata objects in the response, one for each numbered version and one for the $LATEST version.  The GetBotVersions operation always returns at least one version, the $LATEST version. This operation requires permissions for the lex:GetBotVersions action.";
 
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
                GetBotVersionsRequest req = new GetBotVersionsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetBotVersions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}