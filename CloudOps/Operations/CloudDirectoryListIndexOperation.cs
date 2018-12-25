using Amazon;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudDirectoryListIndexOperation : Operation
    {
        public override string Name => "ListIndex";

        public override string Description => "Lists objects attached to the specified index.";
 
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
                ListIndexRequest req = new ListIndexRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListIndex(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}