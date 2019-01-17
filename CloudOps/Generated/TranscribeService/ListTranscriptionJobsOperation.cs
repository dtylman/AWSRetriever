using Amazon;
using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;
using Amazon.Runtime;

namespace CloudOps.TranscribeService
{
    public class ListTranscriptionJobsOperation : Operation
    {
        public override string Name => "ListTranscriptionJobs";

        public override string Description => "Lists transcription jobs with the specified status.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "TranscribeService";

        public override string ServiceID => "Transcribe";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonTranscribeServiceConfig config = new AmazonTranscribeServiceConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonTranscribeServiceClient client = new AmazonTranscribeServiceClient(creds, config);
            
            ListTranscriptionJobsResponse resp = new ListTranscriptionJobsResponse();
            do
            {
                ListTranscriptionJobsRequest req = new ListTranscriptionJobsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListTranscriptionJobs(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.TranscriptionJobSummaries)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}