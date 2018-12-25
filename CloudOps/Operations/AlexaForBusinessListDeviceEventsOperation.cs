using Amazon;
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AlexaForBusinessListDeviceEventsOperation : Operation
    {
        public override string Name => "ListDeviceEvents";

        public override string Description => "Lists the device event history, including device connection status, for up to 30 days.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "AlexaForBusiness";

        public override string ServiceID => "Alexa For Business";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAlexaForBusinessClient client = new AmazonAlexaForBusinessClient(creds, region);
            Response resp = new Response();
            do
            {
                ListDeviceEventsRequest req = new ListDeviceEventsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListDeviceEvents(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}