using Amazon;
using Amazon.Organizations;
using Amazon.Organizations.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class OrganizationsListPoliciesForTargetOperation : Operation
    {
        public override string Name => "ListPoliciesForTarget";

        public override string Description => "Lists the policies that are directly attached to the specified target root, organizational unit (OU), or account. You must specify the policy type that you want included in the returned list.  Always check the NextToken response parameter for a null value when calling a List* operation. These operations can occasionally return an empty set of results even when there are more results available. The NextToken response parameter value is null only when there are no more results to display.  This operation can be called only from the organization&#39;s master account.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "Organizations";

        public override string ServiceID => "Organizations";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonOrganizationsClient client = new AmazonOrganizationsClient(creds, region);
            Response resp = new Response();
            do
            {
                ListPoliciesForTargetRequest req = new ListPoliciesForTargetRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListPoliciesForTarget(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}