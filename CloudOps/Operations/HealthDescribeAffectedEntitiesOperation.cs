using Amazon;
using Amazon.Health;
using Amazon.Health.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class HealthDescribeAffectedEntitiesOperation : Operation
    {
        public override string Name => "DescribeAffectedEntities";

        public override string Description => "Returns a list of entities that have been affected by the specified events, based on the specified filter criteria. Entities can refer to individual customer resources, groups of customer resources, or any other construct, depending on the AWS service. Events that have impact beyond that of the affected entities, or where the extent of impact is unknown, include at least one entity indicating this. At least one event ARN is required. Results are sorted by the lastUpdatedTime of the entity, starting with the most recent.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Health";

        public override string ServiceID => "Health";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonHealthClient client = new AmazonHealthClient(creds, region);
            DescribeAffectedEntitiesResponse resp = new DescribeAffectedEntitiesResponse();
            do
            {
                DescribeAffectedEntitiesRequest req = new DescribeAffectedEntitiesRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.DescribeAffectedEntities(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.entities)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}