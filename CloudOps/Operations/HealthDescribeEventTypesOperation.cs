using Amazon;
using Amazon.Health;
using Amazon.Health.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class HealthDescribeEventTypesOperation : Operation
    {
        public override string Name => "DescribeEventTypes";

        public override string Description => "Returns the event types that meet the specified filter criteria. If no filter criteria are specified, all event types are returned, in no particular order.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Health";

        public override string ServiceID => "Health";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonHealthClient client = new AmazonHealthClient(creds, region);
            DescribeEventTypesResponse resp = new DescribeEventTypesResponse();
            do
            {
                DescribeEventTypesRequest req = new DescribeEventTypesRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.DescribeEventTypes(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.eventTypes)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}