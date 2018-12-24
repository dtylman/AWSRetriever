using Amazon;
using Amazon.Comprehend;
using Amazon.Comprehend.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ComprehendListSentimentDetectionJobsOperation : Operation
    {
        public override string Name => "ListSentimentDetectionJobs";

        public override string Description => "Gets a list of sentiment detection jobs that you have submitted.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Comprehend";

        public override string ServiceID => "Comprehend";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonComprehendClient client = new AmazonComprehendClient(creds, region);
            ListSentimentDetectionJobsResponse resp = new ListSentimentDetectionJobsResponse();
            do
            {
                ListSentimentDetectionJobsRequest req = new ListSentimentDetectionJobsRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListSentimentDetectionJobs(req);
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