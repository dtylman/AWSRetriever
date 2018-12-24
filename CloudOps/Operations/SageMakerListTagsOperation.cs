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
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SageMaker";

        public override string ServiceID => "SageMaker";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSageMakerClient client = new AmazonSageMakerClient(creds, region);
            ListTagsOutput resp = new ListTagsOutput();
            do
            {
                ListTagsInput req = new ListTagsInput
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListTags(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}