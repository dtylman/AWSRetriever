using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.ServiceCatalog
{
    public class ListResourcesForTagOptionOperation : Operation
    {
        public override string Name => "ListResourcesForTagOption";

        public override string Description => "Lists the resources associated with the specified TagOption.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            ListResourcesForTagOptionResponse resp = new ListResourcesForTagOptionResponse();
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
                
                foreach (var obj in resp.ResourceDetails)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.PageToken));
        }
    }
}