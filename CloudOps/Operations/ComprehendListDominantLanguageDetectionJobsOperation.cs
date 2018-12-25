using Amazon;
using Amazon.Comprehend;
using Amazon.Comprehend.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ComprehendListDominantLanguageDetectionJobsOperation : Operation
    {
        public override string Name => "ListDominantLanguageDetectionJobs";

        public override string Description => "Gets a list of the dominant language detection jobs that you have submitted.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Comprehend";

        public override string ServiceID => "Comprehend";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonComprehendClient client = new AmazonComprehendClient(creds, region);
            ListDominantLanguageDetectionJobsResponse resp = new ListDominantLanguageDetectionJobsResponse();
            do
            {
                ListDominantLanguageDetectionJobsRequest req = new ListDominantLanguageDetectionJobsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListDominantLanguageDetectionJobs(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DominantLanguageDetectionJobPropertiesList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}