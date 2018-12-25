using Amazon;
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AlexaForBusinessSearchDevicesOperation : Operation
    {
        public override string Name => "SearchDevices";

        public override string Description => "Searches devices and lists the ones that meet a set of filter criteria.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AlexaForBusiness";

        public override string ServiceID => "Alexa For Business";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAlexaForBusinessClient client = new AmazonAlexaForBusinessClient(creds, region);
            SearchDevicesResponse resp = new SearchDevicesResponse();
            do
            {
                SearchDevicesRequest req = new SearchDevicesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.SearchDevices(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Devices)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}