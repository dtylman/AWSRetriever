using Amazon;
using Amazon.Glue;
using Amazon.Glue.Model;
using Amazon.Runtime;

namespace CloudOps.Glue
{
    public class GetTriggersOperation : Operation
    {
        public override string Name => "GetTriggers";

        public override string Description => "Gets all the triggers associated with a job.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Glue";

        public override string ServiceID => "Glue";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGlueClient client = new AmazonGlueClient(creds, region);
            GetTriggersResponse resp = new GetTriggersResponse();
            do
            {
                GetTriggersRequest req = new GetTriggersRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetTriggers(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Triggers)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}