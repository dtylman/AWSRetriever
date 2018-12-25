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
                GetCommentsForComparedCommitRequest req = new GetCommentsForComparedCommitRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetCommentsForComparedCommit(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}