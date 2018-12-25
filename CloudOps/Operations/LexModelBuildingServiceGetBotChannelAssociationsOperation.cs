using Amazon;
using Amazon.LexModelBuildingService;
using Amazon.LexModelBuildingService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class LexModelBuildingServiceGetBotChannelAssociationsOperation : Operation
    {
        public override string Name => "GetBotChannelAssociations";

        public override string Description => " Returns a list of all of the channels associated with the specified bot.  The GetBotChannelAssociations operation requires permissions for the lex:GetBotChannelAssociations action.";
 
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
                GetBotChannelAssociationsRequest req = new GetBotChannelAssociationsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetBotChannelAssociations(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}