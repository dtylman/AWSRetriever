using Amazon;
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CodeCommitListRepositoriesOperation : Operation
    {
        public override string Name => "ListRepositories";

        public override string Description => "Gets information about one or more repositories.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CodeCommit";

        public override string ServiceID => "CodeCommit";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCodeCommitClient client = new AmazonCodeCommitClient(creds, region);
            ListRepositoriesOutput resp = new ListRepositoriesOutput();
            do
            {
                ListRepositoriesInput req = new ListRepositoriesInput
                {
                    nextToken = resp.nextToken
                                        
                };

                resp = client.ListRepositories(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.repositories)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}