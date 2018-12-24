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
 
        public override string RequestURI => "/applications/{applicationId}/dependencies";

        public override string Method => "GET";

        public override string ServiceName => "ServerlessApplicationRepository";

        public override string ServiceID => "ServerlessApplicationRepository";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServerlessApplicationRepositoryClient client = new AmazonServerlessApplicationRepositoryClient(creds, region);
            ListApplicationDependenciesResponse resp = new ListApplicationDependenciesResponse();
            do
            {
                ListApplicationDependenciesRequest req = new ListApplicationDependenciesRequest
                {
                    NextToken = resp.NextToken,
                    MaxItems = maxItems
                };
                resp = client.ListApplicationDependencies(req);
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}