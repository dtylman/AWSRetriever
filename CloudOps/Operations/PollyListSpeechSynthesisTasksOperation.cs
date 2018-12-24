using Amazon;
using Amazon.Polly;
using Amazon.Polly.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class PollyListSpeechSynthesisTasksOperation : Operation
    {
        public override string Name => "ListSpeechSynthesisTasks";

        public override string Description => "Returns a list of SpeechSynthesisTask objects ordered by their creation date. This operation can filter the tasks by their status, for example, allowing users to list only tasks that are completed.";
 
        public override string RequestURI => "/v1/synthesisTasks";

        public override string Method => "GET";

        public override string ServiceName => "Polly";

        public override string ServiceID => "Polly";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonPollyClient client = new AmazonPollyClient(creds, region);
            ListSpeechSynthesisTasksOutput resp = new ListSpeechSynthesisTasksOutput();
            do
            {
                ListSpeechSynthesisTasksInput req = new ListSpeechSynthesisTasksInput
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListSpeechSynthesisTasks(req);
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}