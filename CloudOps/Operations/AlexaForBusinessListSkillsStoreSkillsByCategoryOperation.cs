using Amazon;
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AlexaForBusinessListSkillsStoreSkillsByCategoryOperation : Operation
    {
        public override string Name => "ListSkillsStoreSkillsByCategory";

        public override string Description => "Lists all skills in the Alexa skill store by category.";
 
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
                ListSkillsStoreSkillsByCategoryRequest req = new ListSkillsStoreSkillsByCategoryRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListSkillsStoreSkillsByCategory(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}