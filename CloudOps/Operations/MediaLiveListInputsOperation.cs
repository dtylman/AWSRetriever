using Amazon;
using Amazon.MediaLive;
using Amazon.MediaLive.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class MediaLiveListInputsOperation : Operation
    {
        public override string Name => "ListInputs";

        public override string Description => "Produces list of inputs that have been created";
 
        public override string RequestURI => "/prod/inputs";

        public override string Method => "GET";

        public override string ServiceName => "MediaLive";

        public override string ServiceID => "MediaLive";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonMediaLiveClient client = new AmazonMediaLiveClient(creds, region);
            ListInputsResponse resp = new ListInputsResponse();
            do
            {
                ListInputsRequest req = new ListInputsRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListInputs(req);
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.Inputs)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}