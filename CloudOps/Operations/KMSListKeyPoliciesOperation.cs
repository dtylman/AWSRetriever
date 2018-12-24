using Amazon;
using Amazon.KMS;
using Amazon.KMS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class KMSListKeyPoliciesOperation : Operation
    {
        public override string Name => "ListKeyPolicies";

        public override string Description => "Gets the names of the key policies that are attached to a customer master key (CMK). This operation is designed to get policy names that you can use in a GetKeyPolicy operation. However, the only valid policy name is default. You cannot perform this operation on a CMK in a different AWS account.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "KMS";

        public override string ServiceID => "KMS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonKMSClient client = new AmazonKMSClient(creds, region);
            ListKeyPoliciesResponse resp = new ListKeyPoliciesResponse();
            do
            {
                ListKeyPoliciesRequest req = new ListKeyPoliciesRequest
                {
                    Marker = resp.NextMarker,
                    Limit = maxItems
                };
                resp = client.ListKeyPolicies(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.PolicyNames)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));
        }
    }
}