using Amazon;
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AlexaForBusinessListSmartHomeAppliancesOperation : Operation
    {
        public override string Name => "ListSmartHomeAppliances";

        public override string Description => "Lists all of the smart home appliances associated with a room.";
 
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
                ListSmartHomeAppliancesRequest req = new ListSmartHomeAppliancesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListSmartHomeAppliances(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}