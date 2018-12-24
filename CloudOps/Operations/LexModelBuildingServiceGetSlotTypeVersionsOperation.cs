using Amazon;
using Amazon.LexModelBuildingService;
using Amazon.LexModelBuildingService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class LexModelBuildingServiceGetSlotTypeVersionsOperation : Operation
    {
        public override string Name => "GetSlotTypeVersions";

        public override string Description => "Gets information about all versions of a slot type. The GetSlotTypeVersions operation returns a SlotTypeMetadata object for each version of a slot type. For example, if a slot type has three numbered versions, the GetSlotTypeVersions operation returns four SlotTypeMetadata objects in the response, one for each numbered version and one for the $LATEST version.  The GetSlotTypeVersions operation always returns at least one version, the $LATEST version. This operation requires permissions for the lex:GetSlotTypeVersions action.";
 
        public override string RequestURI => "/slottypes/{name}/versions/";

        public override string Method => "GET";

        public override string ServiceName => "LexModelBuildingService";

        public override string ServiceID => "Lex Model Building Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonLexModelBuildingServiceClient client = new AmazonLexModelBuildingServiceClient(creds, region);
            GetSlotTypeVersionsResponse resp = new GetSlotTypeVersionsResponse();
            do
            {
                GetSlotTypeVersionsRequest req = new GetSlotTypeVersionsRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.GetSlotTypeVersions(req);
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