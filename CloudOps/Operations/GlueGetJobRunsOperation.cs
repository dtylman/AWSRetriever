using Amazon;
using Amazon.Glue;
using Amazon.Glue.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class GlueGetJobRunsOperation : Operation
    {
        public override string Name => "GetJobRuns";

        public override string Description => "Retrieves metadata for all runs of a given job definition.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "Glue";

        public override string ServiceID => "Glue";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGlueClient client = new AmazonGlueClient(creds, region);
            Response resp = new Response();
            do
            {
                GetJobRunsRequest req = new GetJobRunsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetJobRuns(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}