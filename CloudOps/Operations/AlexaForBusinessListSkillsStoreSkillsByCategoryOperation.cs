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
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AlexaForBusiness";

        public override string ServiceID => "Alexa For Business";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAlexaForBusinessClient client = new AmazonAlexaForBusinessClient(creds, region);
            ListSkillsStoreSkillsByCategoryResponse resp = new ListSkillsStoreSkillsByCategoryResponse();
            do
            {
                ListSkillsStoreSkillsByCategoryRequest req = new ListSkillsStoreSkillsByCategoryRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListSkillsStoreSkillsByCategory(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}