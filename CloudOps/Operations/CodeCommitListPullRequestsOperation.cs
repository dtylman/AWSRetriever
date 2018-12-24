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
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CodeCommit";

        public override string ServiceID => "CodeCommit";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCodeCommitClient client = new AmazonCodeCommitClient(creds, region);
            ListPullRequestsOutput resp = new ListPullRequestsOutput();
            do
            {
                ListPullRequestsInput req = new ListPullRequestsInput
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.ListPullRequests(req);
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