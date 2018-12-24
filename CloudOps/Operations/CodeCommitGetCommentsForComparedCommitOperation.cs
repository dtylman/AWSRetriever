using Amazon;
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CodeCommitGetCommentsForComparedCommitOperation : Operation
    {
        public override string Name => "GetCommentsForComparedCommit";

        public override string Description => "Returns information about comments made on the comparison between two commits.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CodeCommit";

        public override string ServiceID => "CodeCommit";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCodeCommitClient client = new AmazonCodeCommitClient(creds, region);
            GetCommentsForComparedCommitOutput resp = new GetCommentsForComparedCommitOutput();
            do
            {
                GetCommentsForComparedCommitInput req = new GetCommentsForComparedCommitInput
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.GetCommentsForComparedCommit(req);
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