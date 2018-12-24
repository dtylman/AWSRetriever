using Amazon;
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CodeCommitDescribePullRequestEventsOperation : Operation
    {
        public override string Name => "DescribePullRequestEvents";

        public override string Description => "Returns information about one or more pull request events.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CodeCommit";

        public override string ServiceID => "CodeCommit";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCodeCommitClient client = new AmazonCodeCommitClient(creds, region);
            DescribePullRequestEventsOutput resp = new DescribePullRequestEventsOutput();
            do
            {
                DescribePullRequestEventsInput req = new DescribePullRequestEventsInput
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.DescribePullRequestEvents(req);
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