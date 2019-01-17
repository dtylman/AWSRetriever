using Amazon;
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;
using Amazon.Runtime;

namespace CloudOps.CodeCommit
{
    public class GetCommentsForComparedCommitOperation : Operation
    {
        public override string Name => "GetCommentsForComparedCommit";

        public override string Description => "Returns information about comments made on the comparison between two commits.";
 
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
            
            GetCommentsForComparedCommitResponse resp = new GetCommentsForComparedCommitResponse();
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
                
                foreach (var obj in resp.CommentsForComparedCommitData)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}