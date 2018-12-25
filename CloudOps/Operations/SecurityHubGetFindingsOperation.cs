using Amazon;
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SecurityHubGetFindingsOperation : Operation
    {
        public override string Name => "GetFindings";

        public override string Description => "Lists and describes Security Hub-aggregated findings that are specified by filter attributes.";
 
        public override string RequestURI => "/findings";

        public override string Method => "POST";

        public override string ServiceName => "SecurityHub";

        public override string ServiceID => "SecurityHub";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSecurityHubClient client = new AmazonSecurityHubClient(creds, region);
            GetFindingsResponse resp = new GetFindingsResponse();
            do
            {
                GetFindingsRequest req = new GetFindingsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetFindings(req);
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