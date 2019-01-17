using Amazon;
using Amazon.SageMaker;
using Amazon.SageMaker.Model;
using Amazon.Runtime;

namespace CloudOps.SageMaker
{
    public class ListEndpointConfigsOperation : Operation
    {
        public override string Name => "ListEndpointConfigs";

        public override string Description => "Lists endpoint configurations.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SageMaker";

        public override string ServiceID => "SageMaker";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSageMakerConfig config = new AmazonSageMakerConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonSageMakerClient client = new AmazonSageMakerClient(creds, config);
            
            ListEndpointConfigsResponse resp = new ListEndpointConfigsResponse();
            do
            {
                ListEndpointConfigsRequest req = new ListEndpointConfigsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListEndpointConfigs(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.EndpointConfigs)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}