using Amazon;
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class KeyManagementServiceListKeyPoliciesOperation : Operation
    {
        public override string Name => "ListKeyPolicies";

        public override string Description => "Gets the names of the key policies that are attached to a customer master key (CMK). This operation is designed to get policy names that you can use in a GetKeyPolicy operation. However, the only valid policy name is default. You cannot perform this operation on a CMK in a different AWS account.";
 
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
                ListKeyPoliciesRequest req = new ListKeyPoliciesRequest
                {
                    Marker = resp.NextMarker
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.ListKeyPolicies(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.PolicyNames)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));
        }
    }
}