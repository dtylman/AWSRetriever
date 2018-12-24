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
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            ListResourcesForTagOptionOutput resp = new ListResourcesForTagOptionOutput();
            do
            {
                ListResourcesForTagOptionInput req = new ListResourcesForTagOptionInput
                {
                    PageToken = resp.PageToken,
                    PageSize = maxItems
                };
                resp = client.ListResourcesForTagOption(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.PageToken));
        }
    }
}