using Amazon;
using Amazon.Health;
using Amazon.Health.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class HealthDescribeEntityAggregatesOperation : Operation
    {
        public override string Name => "DescribeEntityAggregates";

        public override string Description => "Returns the number of entities that are affected by each of the specified events. If no events are specified, the counts of all affected entities are returned.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Health";

        public override string ServiceID => "Health";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonHealthClient client = new AmazonHealthClient(creds, region);
            DescribeEntityAggregatesResponse resp = new DescribeEntityAggregatesResponse();
            do
            {
                DescribeEntityAggregatesRequest req = new DescribeEntityAggregatesRequest
                {
                    &lt;nil&gt; = resp.&lt;nil&gt;,
                    &lt;nil&gt; = maxItems
                };
                resp = client.DescribeEntityAggregates(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.entityAggregates)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.&lt;nil&gt;));
        }
    }
}