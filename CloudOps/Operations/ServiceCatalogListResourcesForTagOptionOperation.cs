using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServiceCatalogListResourcesForTagOptionOperation : Operation
    {
        public override string Name => "ListResourcesForTagOption";

        public override string Description => "Lists the resources associated with the specified TagOption.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            Response resp = new Response();
            do
            {
                ListResourcesForTagOptionRequest req = new ListResourcesForTagOptionRequest
                {
                    PageToken = resp.PageToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.ListResourcesForTagOption(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.PageToken));
        }
    }
}