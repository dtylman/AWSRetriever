using Amazon;
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IdentityManagementListPolicyVersionsOperation : Operation
    {
        public override string Name => "ListPolicyVersions";

        public override string Description => "Lists information about the versions of the specified managed policy, including the version that is currently set as the policy&#39;s default version. For more information about managed policies, see Managed Policies and Inline Policies in the IAM User Guide.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "IdentityManagement";

        public override string ServiceID => "IAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIdentityManagementClient client = new AmazonIdentityManagementClient(creds, region);
            Response resp = new Response();
            do
            {
                ListPolicyVersionsRequest req = new ListPolicyVersionsRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListPolicyVersions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Versions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}