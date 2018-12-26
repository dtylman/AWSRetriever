using Amazon;
using Amazon.MediaLive;
using Amazon.MediaLive.Model;
using Amazon.Runtime;

namespace CloudOps.MediaLive
{
    public class ListReservationsOperation : Operation
    {
        public override string Name => "ListReservations";

        public override string Description => "List purchased reservations.";
 
        public override string RequestURI => "/prod/reservations";

        public override string Method => "GET";

        public override string ServiceName => "MediaLive";

        public override string ServiceID => "MediaLive";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonMediaLiveClient client = new AmazonMediaLiveClient(creds, region);
            ListReservationsResponse resp = new ListReservationsResponse();
            do
            {
                ListReservationsRequest req = new ListReservationsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListReservations(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Reservations)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}