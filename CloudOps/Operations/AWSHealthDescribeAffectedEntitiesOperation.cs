using Amazon;
using Amazon.AWSHealth;
using Amazon.AWSHealth.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AWSHealthDescribeAffectedEntitiesOperation : Operation
    {
        public override string Name => "DescribeAffectedEntities";

        public override string Description => "Returns a list of entities that have been affected by the specified events, based on the specified filter criteria. Entities can refer to individual customer resources, groups of customer resources, or any other construct, depending on the AWS service. Events that have impact beyond that of the affected entities, or where the extent of impact is unknown, include at least one entity indicating this. At least one event ARN is required. Results are sorted by the lastUpdatedTime of the entity, starting with the most recent.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "AWSHealth";

        public override string ServiceID => "Health";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAWSHealthClient client = new AmazonAWSHealthClient(creds, region);
            Response resp = new Response();
            do
            {
                DescribeAffectedEntitiesRequest req = new DescribeAffectedEntitiesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeAffectedEntities(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Entities)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}