using Amazon;
using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;
using Amazon.Runtime;

namespace CloudOps.TranscribeService
{
    public class ListVocabulariesOperation : Operation
    {
        public override string Name => "ListVocabularies";

        public override string Description => "Returns a list of vocabularies that match the specified criteria. If no criteria are specified, returns the entire list of vocabularies.";
 
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
            
            ListVocabulariesResponse resp = new ListVocabulariesResponse();
            do
            {
                ListVocabulariesRequest req = new ListVocabulariesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListVocabularies(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Vocabularies)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}