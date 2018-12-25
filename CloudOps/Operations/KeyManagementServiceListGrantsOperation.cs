using Amazon;
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class KeyManagementServiceListGrantsOperation : Operation
    {
        public override string Name => "ListGrants";

        public override string Description => "Gets a list of all grants for the specified customer master key (CMK). To perform this operation on a CMK in a different AWS account, specify the key ARN in the value of the KeyId parameter.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "KeyManagementService";

        public override string ServiceID => "KMS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonKeyManagementServiceClient client = new AmazonKeyManagementServiceClient(creds, region);
            Response resp = new Response();
            do
            {
                ListGrantsRequest req = new ListGrantsRequest
                {
                    Marker = resp.NextMarker
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.ListGrants(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Grants)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));
        }
    }
}