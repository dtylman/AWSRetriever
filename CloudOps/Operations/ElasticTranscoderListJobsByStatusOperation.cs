using Amazon;
using Amazon.ElasticTranscoder;
using Amazon.ElasticTranscoder.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElasticTranscoderListJobsByStatusOperation : Operation
    {
        public override string Name => "ListJobsByStatus";

        public override string Description => "The ListJobsByStatus operation gets a list of jobs that have a specified status. The response body contains one element for each job that satisfies the search criteria.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "ElasticTranscoder";

        public override string ServiceID => "Elastic Transcoder";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticTranscoderClient client = new AmazonElasticTranscoderClient(creds, region);
            Response resp = new Response();
            do
            {
                ListJobsByStatusRequest req = new ListJobsByStatusRequest
                {
                    PageToken = resp.NextPageToken
                                        
                };

                resp = client.ListJobsByStatus(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Jobs)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}