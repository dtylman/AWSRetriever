using Amazon;
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CodeCommitGetCommentsForPullRequestOperation : Operation
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
            GetCommentsForPullRequestOutput resp = new GetCommentsForPullRequestOutput();
            do
            {
                GetCommentsForPullRequestInput req = new GetCommentsForPullRequestInput
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.GetCommentsForPullRequest(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}