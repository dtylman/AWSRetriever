using Amazon;
using Amazon.Organizations;
using Amazon.Organizations.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class OrganizationsListHandshakesForAccountOperation : Operation
    {
        public override string Name => "ListHandshakesForAccount";

        public override string Description => "Lists the current handshakes that are associated with the account of the requesting user. Handshakes that are ACCEPTED, DECLINED, or CANCELED appear in the results of this API for only 30 days after changing to that state. After that they are deleted and no longer accessible.  Always check the NextToken response parameter for a null value when calling a List* operation. These operations can occasionally return an empty set of results even when there are more results available. The NextToken response parameter value is null only when there are no more results to display.  This operation can be called from any account in the organization.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Organizations";

        public override string ServiceID => "Organizations";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonOrganizationsClient client = new AmazonOrganizationsClient(creds, region);
            ListHandshakesForAccountResponse resp = new ListHandshakesForAccountResponse();
            do
            {
                ListHandshakesForAccountRequest req = new ListHandshakesForAccountRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListHandshakesForAccount(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}