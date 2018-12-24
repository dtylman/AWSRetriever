using Amazon;
using Amazon.ServerlessApplicationRepository;
using Amazon.ServerlessApplicationRepository.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServerlessApplicationRepositoryListApplicationVersionsOperation : Operation
    {
        public override string Name => "ListApplicationVersions";

        public override string Description => "Lists versions for the specified application.";
 
        public override string RequestURI => "/applications/{applicationId}/versions";

        public override string Method => "GET";

        public override string ServiceName => "ServerlessApplicationRepository";

        public override string ServiceID => "ServerlessApplicationRepository";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServerlessApplicationRepositoryClient client = new AmazonServerlessApplicationRepositoryClient(creds, region);
            ListApplicationVersionsResponse resp = new ListApplicationVersionsResponse();
            do
            {
                ListApplicationVersionsRequest req = new ListApplicationVersionsRequest
                {
                    NextToken = resp.NextToken,
                    MaxItems = maxItems
                };
                resp = client.ListApplicationVersions(req);
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