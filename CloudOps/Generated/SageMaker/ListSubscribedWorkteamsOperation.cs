using Amazon;
using Amazon.SageMaker;
using Amazon.SageMaker.Model;
using Amazon.Runtime;

namespace CloudOps.SageMaker
{
    public class ListSubscribedWorkteamsOperation : Operation
    {
        public override string Name => "ListSubscribedWorkteams";

        public override string Description => "Gets a list of the work teams that you are subscribed to in the AWS Marketplace. The list may be empty if no work team satisfies the filter specified in the NameContains parameter.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SageMaker";

        public override string ServiceID => "SageMaker";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSageMakerClient client = new AmazonSageMakerClient(creds, region);
            ListSubscribedWorkteamsResponse resp = new ListSubscribedWorkteamsResponse();
            do
            {
                ListSubscribedWorkteamsRequest req = new ListSubscribedWorkteamsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListSubscribedWorkteams(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.SubscribedWorkteams)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}