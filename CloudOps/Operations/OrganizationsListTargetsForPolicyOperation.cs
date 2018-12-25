using Amazon;
using Amazon.Organizations;
using Amazon.Organizations.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class OrganizationsListTargetsForPolicyOperation : Operation
    {
        public override string Name => "ListTargetsForPolicy";

        public override string Description => "Lists all the roots, organizaitonal units (OUs), and accounts to which the specified policy is attached.  Always check the NextToken response parameter for a null value when calling a List* operation. These operations can occasionally return an empty set of results even when there are more results available. The NextToken response parameter value is null only when there are no more results to display.  This operation can be called only from the organization&#39;s master account.";
 
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
                ListTargetsForPolicyRequest req = new ListTargetsForPolicyRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListTargetsForPolicy(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}