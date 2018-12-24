using Amazon;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudDirectoryListFacetAttributesOperation : Operation
    {
        public override string Name => "ListFacetAttributes";

        public override string Description => "Retrieves attributes attached to the facet.";
 
        public override string RequestURI => "/amazonclouddirectory/2017-01-11/facet/attributes";

        public override string Method => "POST";

        public override string ServiceName => "CloudDirectory";

        public override string ServiceID => "CloudDirectory";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudDirectoryClient client = new AmazonCloudDirectoryClient(creds, region);
            ListFacetAttributesResponse resp = new ListFacetAttributesResponse();
            do
            {
                ListFacetAttributesRequest req = new ListFacetAttributesRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListFacetAttributes(req);
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