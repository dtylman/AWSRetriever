using Amazon;
using Amazon.ServerlessApplicationRepository;
using Amazon.ServerlessApplicationRepository.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServerlessApplicationRepositoryListApplicationsOperation : Operation
    {
        public override string Name => "ListApplications";

        public override string Description => "Lists applications owned by the requester.";
 
        public override string RequestURI => "/applications";

        public override string Method => "GET";

        public override string ServiceName => "ServerlessApplicationRepository";

        public override string ServiceID => "ServerlessApplicationRepository";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServerlessApplicationRepositoryClient client = new AmazonServerlessApplicationRepositoryClient(creds, region);
            ListApplicationsResponse resp = new ListApplicationsResponse();
            do
            {
                ListApplicationsRequest req = new ListApplicationsRequest
                {
                    NextToken = resp.NextToken,
                    MaxItems = maxItems
                };
                resp = client.ListApplications(req);
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