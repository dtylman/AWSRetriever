using Amazon;
using Amazon.IAM;
using Amazon.IAM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IAMListPolicyVersionsOperation : Operation
    {
        public override string Name => "ListPolicyVersions";

        public override string Description => "Lists information about the versions of the specified managed policy, including the version that is currently set as the policy&#39;s default version. For more information about managed policies, see Managed Policies and Inline Policies in the IAM User Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "IAM";

        public override string ServiceID => "IAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIAMClient client = new AmazonIAMClient(creds, region);
            ListPolicyVersionsResponse resp = new ListPolicyVersionsResponse();
            do
            {
                ListPolicyVersionsRequest req = new ListPolicyVersionsRequest
                {
                    Marker = resp.Marker,
                    MaxItems = maxItems
                };
                resp = client.ListPolicyVersions(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Versions)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}