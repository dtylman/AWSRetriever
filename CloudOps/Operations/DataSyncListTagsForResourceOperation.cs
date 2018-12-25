using Amazon;
using Amazon.DataSync;
using Amazon.DataSync.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DataSyncListTagsForResourceOperation : Operation
    {
        public override string Name => "ListTagsForResource";

        public override string Description => "Returns all the tags associated with a specified resources. ";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "DataSync";

        public override string ServiceID => "DataSync";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDataSyncClient client = new AmazonDataSyncClient(creds, region);
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