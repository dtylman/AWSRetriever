using Amazon;
using Amazon.SageMaker;
using Amazon.SageMaker.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SageMakerListTagsOperation : Operation
    {
        public override string Name => "ListTags";

        public override string Description => "Returns the tags for the specified Amazon SageMaker resource.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "SageMaker";

        public override string ServiceID => "SageMaker";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSageMakerClient client = new AmazonSageMakerClient(creds, region);
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