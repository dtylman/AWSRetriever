using Amazon;
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;
using Amazon.Runtime;

namespace CloudOps.AlexaForBusiness
{
    public class ListSkillsStoreCategoriesOperation : Operation
    {
        public override string Name => "ListSkillsStoreCategories";

        public override string Description => "Lists all categories in the Alexa skill store.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AlexaForBusiness";

        public override string ServiceID => "Alexa For Business";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAlexaForBusinessConfig config = new AmazonAlexaForBusinessConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonAlexaForBusinessClient client = new AmazonAlexaForBusinessClient(creds, config);
            
            ListSkillsStoreCategoriesResponse resp = new ListSkillsStoreCategoriesResponse();
            do
            {
                ListSkillsStoreCategoriesRequest req = new ListSkillsStoreCategoriesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListSkillsStoreCategories(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.CategoryList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}