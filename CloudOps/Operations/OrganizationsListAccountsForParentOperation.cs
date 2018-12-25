using Amazon;
using Amazon.Organizations;
using Amazon.Organizations.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class OrganizationsListAccountsForParentOperation : Operation
    {
        public override string Name => "ListAccountsForParent";

        public override string Description => "Lists the accounts in an organization that are contained by the specified target root or organizational unit (OU). If you specify the root, you get a list of all the accounts that are not in any OU. If you specify an OU, you get a list of all the accounts in only that OU, and not in any child OUs. To get a list of all accounts in the organization, use the ListAccounts operation.  Always check the NextToken response parameter for a null value when calling a List* operation. These operations can occasionally return an empty set of results even when there are more results available. The NextToken response parameter value is null only when there are no more results to display.  This operation can be called only from the organization&#39;s master account.";
 
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
                ListAccountsForParentRequest req = new ListAccountsForParentRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListAccountsForParent(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}