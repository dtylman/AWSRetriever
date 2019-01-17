using Amazon;
using Amazon.Chime;
using Amazon.Chime.Model;
using Amazon.Runtime;

namespace CloudOps.Chime
{
    public class ListAccountsOperation : Operation
    {
        public override string Name => "ListAccounts";

        public override string Description => "Lists the Amazon Chime accounts under the administrator&#39;s AWS account. You can filter accounts by account name prefix. To find out which Amazon Chime account a user belongs to, you can filter by the user&#39;s email address, which returns one account result.";
 
        public override string RequestURI => "/console/accounts";

        public override string Method => "GET";

        public override string ServiceName => "Chime";

        public override string ServiceID => "Chime";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonChimeConfig config = new AmazonChimeConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonChimeClient client = new AmazonChimeClient(creds, config);
            
            ListAccountsResponse resp = new ListAccountsResponse();
            do
            {
                ListAccountsRequest req = new ListAccountsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListAccounts(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Accounts)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}