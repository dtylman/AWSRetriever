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
 
        public override string RequestURI => "/2012-09-25/jobsByStatus/{Status}";

        public override string Method => "GET";

        public override string ServiceName => "ElasticTranscoder";

        public override string ServiceID => "Elastic Transcoder";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticTranscoderClient client = new AmazonElasticTranscoderClient(creds, region);
            ListJobsByStatusResponse resp = new ListJobsByStatusResponse();
            do
            {
                ListJobsByStatusRequest req = new ListJobsByStatusRequest
                {
                    PageToken = resp.NextPageToken,
                    &lt;nil&gt; = maxItems
                };
                resp = client.ListJobsByStatus(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Jobs)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}