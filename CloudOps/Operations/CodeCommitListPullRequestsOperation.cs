using Amazon;
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CodeCommitListPullRequestsOperation : Operation
    {
        public override string Name => "ListPullRequests";

        public override string Description => "Returns a list of pull requests for a specified repository. The return list can be refined by pull request status or pull request author ARN.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "CodeCommit";

        public override string ServiceID => "CodeCommit";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCodeCommitClient client = new AmazonCodeCommitClient(creds, region);
            Response resp = new Response();
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
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}