using Amazon;
using Amazon.SageMaker;
using Amazon.SageMaker.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SageMakerListEndpointsOperation : Operation
    {
        public override string Name => "ListEndpoints";

        public override string Description => "Lists endpoints.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SageMaker";

        public override string ServiceID => "SageMaker";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSageMakerClient client = new AmazonSageMakerClient(creds, region);
            ListEndpointsOutput resp = new ListEndpointsOutput();
            do
            {
                ListEndpointsInput req = new ListEndpointsInput
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListEndpoints(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Endpoints)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}