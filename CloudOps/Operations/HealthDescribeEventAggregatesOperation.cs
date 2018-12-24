using Amazon;
using Amazon.Health;
using Amazon.Health.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class HealthDescribeEventAggregatesOperation : Operation
    {
        public override string Name => "DescribeEventAggregates";

        public override string Description => "Returns the number of events of each event type (issue, scheduled change, and account notification). If no filter is specified, the counts of all events in each category are returned.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Health";

        public override string ServiceID => "Health";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonHealthClient client = new AmazonHealthClient(creds, region);
            DescribeEventAggregatesResponse resp = new DescribeEventAggregatesResponse();
            do
            {
                DescribeEventAggregatesRequest req = new DescribeEventAggregatesRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.DescribeEventAggregates(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.eventAggregates)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}