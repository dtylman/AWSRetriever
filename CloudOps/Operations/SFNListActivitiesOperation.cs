using Amazon;
using Amazon.SFN;
using Amazon.SFN.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SFNListActivitiesOperation : Operation
    {
        public override string Name => "ListActivities";

        public override string Description => "Lists the existing activities. If nextToken is returned, there are more results available. The value of nextToken is a unique pagination token for each page. Make the call again using the returned token to retrieve the next page. Keep all other arguments unchanged. Each pagination token expires after 24 hours. Using an expired pagination token will return an HTTP 400 InvalidToken error.  This operation is eventually consistent. The results are best effort and may not reflect very recent updates and changes. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SFN";

        public override string ServiceID => "SFN";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSFNClient client = new AmazonSFNClient(creds, region);
            ListActivitiesOutput resp = new ListActivitiesOutput();
            do
            {
                ListActivitiesInput req = new ListActivitiesInput
                {
                    nextToken = resp.nextToken
                    ,
                    maxResults = maxItems
                                        
                };

                resp = client.ListActivities(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.activities)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}