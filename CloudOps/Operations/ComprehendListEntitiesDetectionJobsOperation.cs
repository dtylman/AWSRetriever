using Amazon;
using Amazon.Comprehend;
using Amazon.Comprehend.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ComprehendListEntitiesDetectionJobsOperation : Operation
    {
        public override string Name => "ListEntitiesDetectionJobs";

        public override string Description => "Gets a list of the entity detection jobs that you have submitted.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Comprehend";

        public override string ServiceID => "Comprehend";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonComprehendClient client = new AmazonComprehendClient(creds, region);
            ListEntitiesDetectionJobsResponse resp = new ListEntitiesDetectionJobsResponse();
            do
            {
                ListEntitiesDetectionJobsRequest req = new ListEntitiesDetectionJobsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListEntitiesDetectionJobs(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.EntitiesDetectionJobPropertiesList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}