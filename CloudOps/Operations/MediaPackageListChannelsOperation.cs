using Amazon;
using Amazon.MediaPackage;
using Amazon.MediaPackage.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class MediaPackageListChannelsOperation : Operation
    {
        public override string Name => "ListChannels";

        public override string Description => "Returns a collection of Channels.";
 
        public override string RequestURI => "/channels";

        public override string Method => "GET";

        public override string ServiceName => "MediaPackage";

        public override string ServiceID => "MediaPackage";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonMediaPackageClient client = new AmazonMediaPackageClient(creds, region);
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