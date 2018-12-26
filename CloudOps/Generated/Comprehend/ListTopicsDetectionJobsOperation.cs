using Amazon;
using Amazon.Comprehend;
using Amazon.Comprehend.Model;
using Amazon.Runtime;

namespace CloudOps.Comprehend
{
    public class ListTopicsDetectionJobsOperation : Operation
    {
        public override string Name => "ListTopicsDetectionJobs";

        public override string Description => "Gets a list of the topic detection jobs that you have submitted.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Comprehend";

        public override string ServiceID => "Comprehend";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonComprehendClient client = new AmazonComprehendClient(creds, region);
            ListTopicsDetectionJobsResponse resp = new ListTopicsDetectionJobsResponse();
            do
            {
                ListTopicsDetectionJobsRequest req = new ListTopicsDetectionJobsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListTopicsDetectionJobs(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.TopicsDetectionJobPropertiesList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}