using Amazon;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudDirectoryListTagsForResourceOperation : Operation
    {
        public override string Name => "ListTagsForResource";

        public override string Description => "Returns tags for a resource. Tagging is currently supported only for directories with a limit of 50 tags per directory. All 50 tags are returned for a given directory with this API call.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "CloudDirectory";

        public override string ServiceID => "CloudDirectory";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudDirectoryClient client = new AmazonCloudDirectoryClient(creds, region);
            Response resp = new Response();
            do
            {
                ListTagsForResourceRequest req = new ListTagsForResourceRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListTagsForResource(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}