using Amazon;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudDirectoryListObjectParentsOperation : Operation
    {
        public override string Name => "ListObjectParents";

        public override string Description => "Lists parent objects that are associated with a given object in pagination fashion.";
 
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
                ListObjectParentsRequest req = new ListObjectParentsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListObjectParents(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}