using Amazon;
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DirectoryServiceDescribeDomainControllersOperation : Operation
    {
        public override string Name => "DescribeDomainControllers";

        public override string Description => "Provides information about any domain controllers in your directory.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "DirectoryService";

        public override string ServiceID => "Directory Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDirectoryServiceClient client = new AmazonDirectoryServiceClient(creds, region);
            Response resp = new Response();
            do
            {
                DescribeDomainControllersRequest req = new DescribeDomainControllersRequest
                {
                    NextToken = resp.NextToken
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.DescribeDomainControllers(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}