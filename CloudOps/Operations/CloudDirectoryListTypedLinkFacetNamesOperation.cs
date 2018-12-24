using Amazon;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudDirectoryListTypedLinkFacetNamesOperation : Operation
    {
        public override string Name => "ListTypedLinkFacetNames";

        public override string Description => "Returns a paginated list of TypedLink facet names for a particular schema. For more information, see Typed Links.";
 
        public override string RequestURI => "/amazonclouddirectory/2017-01-11/typedlink/facet/list";

        public override string Method => "POST";

        public override string ServiceName => "CloudDirectory";

        public override string ServiceID => "CloudDirectory";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudDirectoryClient client = new AmazonCloudDirectoryClient(creds, region);
            ListTypedLinkFacetNamesResponse resp = new ListTypedLinkFacetNamesResponse();
            do
            {
                ListTypedLinkFacetNamesRequest req = new ListTypedLinkFacetNamesRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListTypedLinkFacetNames(req);
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