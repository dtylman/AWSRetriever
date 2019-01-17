using Amazon;
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;
using Amazon.Runtime;

namespace CloudOps.CodeCommit
{
    public class GetDifferencesOperation : Operation
    {
        public override string Name => "GetDifferences";

        public override string Description => "Returns information about the differences in a valid commit specifier (such as a branch, tag, HEAD, commit ID or other fully qualified reference). Results can be limited to a specified path.";
 
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
            
            GetDifferencesResponse resp = new GetDifferencesResponse();
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
                
                foreach (var obj in resp.Differences)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}