using Amazon;
using Amazon.LexModelBuildingService;
using Amazon.LexModelBuildingService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class LexModelBuildingServiceGetBuiltinIntentsOperation : Operation
    {
        public override string Name => "GetBuiltinIntents";

        public override string Description => "Gets a list of built-in intents that meet the specified criteria. This operation requires permission for the lex:GetBuiltinIntents action.";
 
        public override string RequestURI => "/builtins/intents/";

        public override string Method => "GET";

        public override string ServiceName => "LexModelBuildingService";

        public override string ServiceID => "Lex Model Building Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonLexModelBuildingServiceClient client = new AmazonLexModelBuildingServiceClient(creds, region);
            GetBuiltinIntentsResponse resp = new GetBuiltinIntentsResponse();
            do
            {
                GetBuiltinIntentsRequest req = new GetBuiltinIntentsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetBuiltinIntents(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Intents)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}