using Amazon;
using Amazon.ServerlessApplicationRepository;
using Amazon.ServerlessApplicationRepository.Model;
using Amazon.Runtime;

namespace CloudOps.ServerlessApplicationRepository
{
    public class ListApplicationsOperation : Operation
    {
        public override string Name => "ListApplications";

        public override string Description => "Lists applications owned by the requester.";
 
        public override string RequestURI => "/applications";

        public override string Method => "GET";

        public override string ServiceName => "ServerlessApplicationRepository";

        public override string ServiceID => "ServerlessApplicationRepository";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServerlessApplicationRepositoryConfig config = new AmazonServerlessApplicationRepositoryConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonServerlessApplicationRepositoryClient client = new AmazonServerlessApplicationRepositoryClient(creds, config);
            
            ListApplicationsResponse resp = new ListApplicationsResponse();
            do
            {
                ListApplicationsRequest req = new ListApplicationsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListApplications(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Applications)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}