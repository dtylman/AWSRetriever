using Amazon;
using Amazon.Comprehend;
using Amazon.Comprehend.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ComprehendListKeyPhrasesDetectionJobsOperation : Operation
    {
        public override string Name => "ListKeyPhrasesDetectionJobs";

        public override string Description => "Get a list of key phrase detection jobs that you have submitted.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Comprehend";

        public override string ServiceID => "Comprehend";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonComprehendClient client = new AmazonComprehendClient(creds, region);
            ListKeyPhrasesDetectionJobsResponse resp = new ListKeyPhrasesDetectionJobsResponse();
            do
            {
                ListKeyPhrasesDetectionJobsRequest req = new ListKeyPhrasesDetectionJobsRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListKeyPhrasesDetectionJobs(req);
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