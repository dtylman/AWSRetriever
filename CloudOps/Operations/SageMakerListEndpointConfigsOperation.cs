using Amazon;
using Amazon.SageMaker;
using Amazon.SageMaker.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SageMakerListEndpointConfigsOperation : Operation
    {
        public override string Name => "ListEndpointConfigs";

        public override string Description => "Lists endpoint configurations.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SageMaker";

        public override string ServiceID => "SageMaker";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSageMakerClient client = new AmazonSageMakerClient(creds, region);
            ListEndpointConfigsOutput resp = new ListEndpointConfigsOutput();
            do
            {
                ListEndpointConfigsInput req = new ListEndpointConfigsInput
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListEndpointConfigs(req);
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