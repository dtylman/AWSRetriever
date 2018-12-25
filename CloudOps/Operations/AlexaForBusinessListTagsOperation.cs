using Amazon;
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AlexaForBusinessListTagsOperation : Operation
    {
        public override string Name => "ListTags";

        public override string Description => "Lists all tags for the specified resource.";
 
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
                ListTagsRequest req = new ListTagsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListTags(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}