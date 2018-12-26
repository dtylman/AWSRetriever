using Amazon;
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;
using Amazon.Runtime;

namespace CloudOps.AlexaForBusiness
{
    public class SearchAddressBooksOperation : Operation
    {
        public override string Name => "SearchAddressBooks";

        public override string Description => "Searches address books and lists the ones that meet a set of filter and sort criteria.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AlexaForBusiness";

        public override string ServiceID => "Alexa For Business";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAlexaForBusinessClient client = new AmazonAlexaForBusinessClient(creds, region);
            SearchAddressBooksResponse resp = new SearchAddressBooksResponse();
            do
            {
                SearchAddressBooksRequest req = new SearchAddressBooksRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.SearchAddressBooks(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.AddressBooks)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}