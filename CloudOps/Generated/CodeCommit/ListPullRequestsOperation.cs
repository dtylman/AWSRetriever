using Amazon;
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;
using Amazon.Runtime;

namespace CloudOps.CodeCommit
{
    public class ListPullRequestsOperation : Operation
    {
        public override string Name => "ListPullRequests";

        public override string Description => "Returns a list of pull requests for a specified repository. The return list can be refined by pull request status or pull request author ARN.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CodeCommit";

        public override string ServiceID => "CodeCommit";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCodeCommitConfig config = new AmazonCodeCommitConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonCodeCommitClient client = new AmazonCodeCommitClient(creds, config);
            
            ListPullRequestsResponse resp = new ListPullRequestsResponse();
            do
            {
                ListPullRequestsRequest req = new ListPullRequestsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListPullRequests(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.PullRequestIds)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}