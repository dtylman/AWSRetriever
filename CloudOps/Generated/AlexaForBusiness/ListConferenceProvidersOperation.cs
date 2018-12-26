using Amazon;
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;
using Amazon.Runtime;

namespace CloudOps.AlexaForBusiness
{
    public class ListConferenceProvidersOperation : Operation
    {
        public override string Name => "ListConferenceProviders";

        public override string Description => "Lists conference providers under a specific AWS account.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AlexaForBusiness";

        public override string ServiceID => "Alexa For Business";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAlexaForBusinessClient client = new AmazonAlexaForBusinessClient(creds, region);
            ListConferenceProvidersResponse resp = new ListConferenceProvidersResponse();
            do
            {
                ListConferenceProvidersRequest req = new ListConferenceProvidersRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListConferenceProviders(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ConferenceProviders)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}