using Amazon;
using Amazon.MediaLive;
using Amazon.MediaLive.Model;
using Amazon.Runtime;

namespace CloudOps.MediaLive
{
    public class ListOfferingsOperation : Operation
    {
        public override string Name => "ListOfferings";

        public override string Description => "List offerings available for purchase.";
 
        public override string RequestURI => "/prod/offerings";

        public override string Method => "GET";

        public override string ServiceName => "MediaLive";

        public override string ServiceID => "MediaLive";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonMediaLiveConfig config = new AmazonMediaLiveConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonMediaLiveClient client = new AmazonMediaLiveClient(creds, config);
            
            ListOfferingsResponse resp = new ListOfferingsResponse();
            do
            {
                ListOfferingsRequest req = new ListOfferingsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListOfferings(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Offerings)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}