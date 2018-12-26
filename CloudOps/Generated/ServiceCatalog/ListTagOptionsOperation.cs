using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.ServiceCatalog
{
    public class ListTagOptionsOperation : Operation
    {
        public override string Name => "ListTagOptions";

        public override string Description => "Lists the specified TagOptions or all TagOptions.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            ListTagOptionsResponse resp = new ListTagOptionsResponse();
            do
            {
                ListTagOptionsRequest req = new ListTagOptionsRequest
                {
                    PageToken = resp.PageToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.ListTagOptions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.TagOptionDetails)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.PageToken));
        }
    }
}