using Amazon;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudDirectoryLookupPolicyOperation : Operation
    {
        public override string Name => "LookupPolicy";

        public override string Description => "Lists all policies from the root of the Directory to the object specified. If there are no policies present, an empty list is returned. If policies are present, and if some objects don&#39;t have the policies attached, it returns the ObjectIdentifier for such objects. If policies are present, it returns ObjectIdentifier, policyId, and policyType. Paths that don&#39;t lead to the root from the target object are ignored. For more information, see Policies.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "CloudDirectory";

        public override string ServiceID => "CloudDirectory";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudDirectoryClient client = new AmazonCloudDirectoryClient(creds, region);
            Response resp = new Response();
            do
            {
                LookupPolicyRequest req = new LookupPolicyRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.LookupPolicy(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}