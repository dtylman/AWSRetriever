using Amazon;
using Amazon.LexModelBuildingService;
using Amazon.LexModelBuildingService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class LexModelBuildingServiceGetSlotTypesOperation : Operation
    {
        public override string Name => "GetSlotTypes";

        public override string Description => "Returns slot type information as follows:    If you specify the nameContains field, returns the $LATEST version of all slot types that contain the specified string.    If you don&#39;t specify the nameContains field, returns information about the $LATEST version of all slot types.     The operation requires permission for the lex:GetSlotTypes action. ";
 
        public override string RequestURI => "/slottypes/";

        public override string Method => "GET";

        public override string ServiceName => "LexModelBuildingService";

        public override string ServiceID => "Lex Model Building Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonLexModelBuildingServiceClient client = new AmazonLexModelBuildingServiceClient(creds, region);
            GetSlotTypesResponse resp = new GetSlotTypesResponse();
            do
            {
                GetSlotTypesRequest req = new GetSlotTypesRequest
                {
                    nextToken = resp.nextToken
                    ,
                    maxResults = maxItems
                                        
                };

                resp = client.GetSlotTypes(req);
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