using Amazon;
using Amazon.MediaLive;
using Amazon.MediaLive.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class MediaLiveDescribeScheduleOperation : Operation
    {
        public override string Name => "DescribeSchedule";

        public override string Description => "Get a channel schedule";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "MediaLive";

        public override string ServiceID => "MediaLive";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonMediaLiveClient client = new AmazonMediaLiveClient(creds, region);
            Response resp = new Response();
            do
            {
                DescribeScheduleRequest req = new DescribeScheduleRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeSchedule(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ScheduleActions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}