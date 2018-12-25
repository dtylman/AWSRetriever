using Amazon;
using Amazon.CloudHSMV2;
using Amazon.CloudHSMV2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudHSMV2ListTagsOperation : Operation
    {
        public override string Name => "ListTags";

        public override string Description => "Gets a list of tags for the specified AWS CloudHSM cluster. This is a paginated operation, which means that each response might contain only a subset of all the tags. When the response contains only a subset of tags, it includes a NextToken value. Use this value in a subsequent ListTags request to get more tags. When you receive a response with no NextToken (or an empty or null value), that means there are no more tags to get.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "CloudHSMV2";

        public override string ServiceID => "CloudHSM V2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudHSMV2Client client = new AmazonCloudHSMV2Client(creds, region);
            Response resp = new Response();
            do
            {
                ListTagsRequest req = new ListTagsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListTags(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}