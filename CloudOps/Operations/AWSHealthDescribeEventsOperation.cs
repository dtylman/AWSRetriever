using Amazon;
using Amazon.AWSHealth;
using Amazon.AWSHealth.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AWSHealthDescribeEventsOperation : Operation
    {
        public override string Name => "DescribeEvents";

        public override string Description => "Returns information about events that meet the specified filter criteria. Events are returned in a summary form and do not include the detailed description, any additional metadata that depends on the event type, or any affected resources. To retrieve that information, use the DescribeEventDetails and DescribeAffectedEntities operations. If no filter criteria are specified, all events are returned. Results are sorted by lastModifiedTime, starting with the most recent.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AWSHealth";

        public override string ServiceID => "Health";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAWSHealthClient client = new AmazonAWSHealthClient(creds, region);
            DescribeEventsResponse resp = new DescribeEventsResponse();
            do
            {
                DescribeEventsRequest req = new DescribeEventsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeEvents(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Events)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}