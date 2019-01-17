using Amazon;
using Amazon.SageMaker;
using Amazon.SageMaker.Model;
using Amazon.Runtime;

namespace CloudOps.SageMaker
{
    public class ListNotebookInstancesOperation : Operation
    {
        public override string Name => "ListNotebookInstances";

        public override string Description => "Returns a list of the Amazon SageMaker notebook instances in the requester&#39;s account in an AWS Region. ";
 
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
            
            ListNotebookInstancesResponse resp = new ListNotebookInstancesResponse();
            do
            {
                ListNotebookInstancesRequest req = new ListNotebookInstancesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListNotebookInstances(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.NotebookInstances)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}