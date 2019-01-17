using Amazon;
using Amazon.ElasticTranscoder;
using Amazon.ElasticTranscoder.Model;
using Amazon.Runtime;

namespace CloudOps.ElasticTranscoder
{
    public class ListPipelinesOperation : Operation
    {
        public override string Name => "ListPipelines";

        public override string Description => "The ListPipelines operation gets a list of the pipelines associated with the current AWS account.";
 
        public override string RequestURI => "/2012-09-25/pipelines";

        public override string Method => "GET";

        public override string ServiceName => "ElasticTranscoder";

        public override string ServiceID => "Elastic Transcoder";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticTranscoderConfig config = new AmazonElasticTranscoderConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonElasticTranscoderClient client = new AmazonElasticTranscoderClient(creds, config);
            
            ListPipelinesResponse resp = new ListPipelinesResponse();
            do
            {
                ListPipelinesRequest req = new ListPipelinesRequest
                {
                    PageToken = resp.NextPageToken
                                        
                };

                resp = client.ListPipelines(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Pipelines)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}