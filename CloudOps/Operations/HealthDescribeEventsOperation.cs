using Amazon;
using Amazon.Health;
using Amazon.Health.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class HealthDescribeEventsOperation : Operation
    {
        public override string Name => "DescribeEvents";

        public override string Description => "Returns information about events that meet the specified filter criteria. Events are returned in a summary form and do not include the detailed description, any additional metadata that depends on the event type, or any affected resources. To retrieve that information, use the DescribeEventDetails and DescribeAffectedEntities operations. If no filter criteria are specified, all events are returned. Results are sorted by lastModifiedTime, starting with the most recent.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Health";

        public override string ServiceID => "Health";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonHealthClient client = new AmazonHealthClient(creds, region);
            DescribeEventsResponse resp = new DescribeEventsResponse();
            do
            {
                DescribeEventsRequest req = new DescribeEventsRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.DescribeEvents(req);
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