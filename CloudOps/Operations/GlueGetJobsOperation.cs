using Amazon;
using Amazon.Glue;
using Amazon.Glue.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class GlueGetJobsOperation : Operation
    {
        public override string Name => "GetJobs";

        public override string Description => "Retrieves all current job definitions.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Glue";

        public override string ServiceID => "Glue";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGlueClient client = new AmazonGlueClient(creds, region);
            GetJobsResponse resp = new GetJobsResponse();
            do
            {
                GetJobsRequest req = new GetJobsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetJobs(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Jobs)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}