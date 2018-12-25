using Amazon;
using Amazon.SageMaker;
using Amazon.SageMaker.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SageMakerListNotebookInstanceLifecycleConfigsOperation : Operation
    {
        public override string Name => "ListNotebookInstanceLifecycleConfigs";

        public override string Description => "Lists notebook instance lifestyle configurations created with the CreateNotebookInstanceLifecycleConfig API.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SageMaker";

        public override string ServiceID => "SageMaker";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSageMakerClient client = new AmazonSageMakerClient(creds, region);
            ListNotebookInstanceLifecycleConfigsOutput resp = new ListNotebookInstanceLifecycleConfigsOutput();
            do
            {
                ListNotebookInstanceLifecycleConfigsInput req = new ListNotebookInstanceLifecycleConfigsInput
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListNotebookInstanceLifecycleConfigs(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.NotebookInstanceLifecycleConfigs)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}