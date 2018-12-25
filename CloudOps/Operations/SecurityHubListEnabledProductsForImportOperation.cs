using Amazon;
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SecurityHubListEnabledProductsForImportOperation : Operation
    {
        public override string Name => "ListEnabledProductsForImport";

        public override string Description => "Lists all Security Hub-integrated third-party findings providers.";
 
        public override string RequestURI => "/productSubscriptions";

        public override string Method => "GET";

        public override string ServiceName => "SecurityHub";

        public override string ServiceID => "SecurityHub";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSecurityHubClient client = new AmazonSecurityHubClient(creds, region);
            ListEnabledProductsForImportResponse resp = new ListEnabledProductsForImportResponse();
            do
            {
                ListEnabledProductsForImportRequest req = new ListEnabledProductsForImportRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListEnabledProductsForImport(req);
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