using Amazon;
using Amazon.SFN;
using Amazon.SFN.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SFNListExecutionsOperation : Operation
    {
        public override string Name => "ListExecutions";

        public override string Description => "Lists the executions of a state machine that meet the filtering criteria. Results are sorted by time, with the most recent execution first. If nextToken is returned, there are more results available. The value of nextToken is a unique pagination token for each page. Make the call again using the returned token to retrieve the next page. Keep all other arguments unchanged. Each pagination token expires after 24 hours. Using an expired pagination token will return an HTTP 400 InvalidToken error.  This operation is eventually consistent. The results are best effort and may not reflect very recent updates and changes. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SFN";

        public override string ServiceID => "SFN";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSFNClient client = new AmazonSFNClient(creds, region);
            ListExecutionsOutput resp = new ListExecutionsOutput();
            do
            {
                ListExecutionsInput req = new ListExecutionsInput
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.ListExecutions(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.executions)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}