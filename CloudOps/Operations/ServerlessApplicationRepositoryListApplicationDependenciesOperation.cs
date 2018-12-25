using Amazon;
using Amazon.ServerlessApplicationRepository;
using Amazon.ServerlessApplicationRepository.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServerlessApplicationRepositoryListApplicationDependenciesOperation : Operation
    {
        public override string Name => "ListApplicationDependencies";

        public override string Description => "Retrieves the list of applications nested in the containing application.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "ServerlessApplicationRepository";

        public override string ServiceID => "ServerlessApplicationRepository";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServerlessApplicationRepositoryClient client = new AmazonServerlessApplicationRepositoryClient(creds, region);
            Response resp = new Response();
            do
            {
                ListApplicationDependenciesRequest req = new ListApplicationDependenciesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListApplicationDependencies(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}