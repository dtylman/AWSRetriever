using Amazon;
using Amazon.LexModelBuildingService;
using Amazon.LexModelBuildingService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class LexModelBuildingServiceGetIntentVersionsOperation : Operation
    {
        public override string Name => "GetIntentVersions";

        public override string Description => "Gets information about all of the versions of an intent. The GetIntentVersions operation returns an IntentMetadata object for each version of an intent. For example, if an intent has three numbered versions, the GetIntentVersions operation returns four IntentMetadata objects in the response, one for each numbered version and one for the $LATEST version.  The GetIntentVersions operation always returns at least one version, the $LATEST version. This operation requires permissions for the lex:GetIntentVersions action.";
 
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
                GetIntentVersionsRequest req = new GetIntentVersionsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetIntentVersions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}