using Amazon;
using Amazon.MediaLive;
using Amazon.MediaLive.Model;
using Amazon.Runtime;

namespace CloudOps.MediaLive
{
    public class ListChannelsOperation : Operation
    {
        public override string Name => "ListChannels";

        public override string Description => "Produces list of channels that have been created";
 
        public override string RequestURI => "/prod/channels";

        public override string Method => "GET";

        public override string ServiceName => "MediaLive";

        public override string ServiceID => "MediaLive";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonMediaLiveConfig config = new AmazonMediaLiveConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonMediaLiveClient client = new AmazonMediaLiveClient(creds, config);
            
            ListChannelsResponse resp = new ListChannelsResponse();
            do
            {
                ListChannelsRequest req = new ListChannelsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListChannels(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Channels)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}