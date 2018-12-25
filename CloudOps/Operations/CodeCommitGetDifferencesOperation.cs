using Amazon;
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CodeCommitGetDifferencesOperation : Operation
    {
        public override string Name => "GetDifferences";

        public override string Description => "Returns information about the differences in a valid commit specifier (such as a branch, tag, HEAD, commit ID or other fully qualified reference). Results can be limited to a specified path.";
 
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
                GetDifferencesRequest req = new GetDifferencesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetDifferences(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}