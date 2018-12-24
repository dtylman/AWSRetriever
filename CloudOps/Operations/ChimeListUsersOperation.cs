using Amazon;
using Amazon.Chime;
using Amazon.Chime.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ChimeListUsersOperation : Operation
    {
        public override string Name => "ListUsers";

        public override string Description => "Lists the users that belong to the specified Amazon Chime account. You can specify an email address to list only the user that the email address belongs to.";
 
        public override string RequestURI => "/console/accounts/{accountId}/users";

        public override string Method => "GET";

        public override string ServiceName => "Chime";

        public override string ServiceID => "Chime";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonChimeClient client = new AmazonChimeClient(creds, region);
            ListUsersResponse resp = new ListUsersResponse();
            do
            {
                ListUsersRequest req = new ListUsersRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListUsers(req);
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