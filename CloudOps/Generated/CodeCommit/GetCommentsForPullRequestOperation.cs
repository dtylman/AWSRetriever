using Amazon;
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;
using Amazon.Runtime;

namespace CloudOps.CodeCommit
{
    public class GetCommentsForPullRequestOperation : Operation
    {
        public override string Name => "GetCommentsForPullRequest";

        public override string Description => "Returns comments made on a pull request.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CodeCommit";

        public override string ServiceID => "CodeCommit";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCodeCommitClient client = new AmazonCodeCommitClient(creds, region);
            GetCommentsForPullRequestResponse resp = new GetCommentsForPullRequestResponse();
            do
            {
                GetCommentsForPullRequestRequest req = new GetCommentsForPullRequestRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetCommentsForPullRequest(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.CommentsForPullRequestData)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}