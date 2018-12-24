using Amazon;
using Amazon.SFN;
using Amazon.SFN.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SFNGetExecutionHistoryOperation : Operation
    {
        public override string Name => "GetExecutionHistory";

        public override string Description => "Returns the history of the specified execution as a list of events. By default, the results are returned in ascending order of the timeStamp of the events. Use the reverseOrder parameter to get the latest events first. If nextToken is returned, there are more results available. The value of nextToken is a unique pagination token for each page. Make the call again using the returned token to retrieve the next page. Keep all other arguments unchanged. Each pagination token expires after 24 hours. Using an expired pagination token will return an HTTP 400 InvalidToken error.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SFN";

        public override string ServiceID => "SFN";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSFNClient client = new AmazonSFNClient(creds, region);
            GetExecutionHistoryOutput resp = new GetExecutionHistoryOutput();
            do
            {
                GetExecutionHistoryInput req = new GetExecutionHistoryInput
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.GetExecutionHistory(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.events)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}