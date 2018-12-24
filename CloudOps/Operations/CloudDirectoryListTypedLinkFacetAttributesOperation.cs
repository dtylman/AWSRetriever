using Amazon;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudDirectoryListTypedLinkFacetAttributesOperation : Operation
    {
        public override string Name => "ListTypedLinkFacetAttributes";

        public override string Description => "Returns a paginated list of all attribute definitions for a particular TypedLinkFacet. For more information, see Typed Links.";
 
        public override string RequestURI => "/amazonclouddirectory/2017-01-11/typedlink/facet/attributes";

        public override string Method => "POST";

        public override string ServiceName => "CloudDirectory";

        public override string ServiceID => "CloudDirectory";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudDirectoryClient client = new AmazonCloudDirectoryClient(creds, region);
            ListTypedLinkFacetAttributesResponse resp = new ListTypedLinkFacetAttributesResponse();
            do
            {
                ListTypedLinkFacetAttributesRequest req = new ListTypedLinkFacetAttributesRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListTypedLinkFacetAttributes(req);
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