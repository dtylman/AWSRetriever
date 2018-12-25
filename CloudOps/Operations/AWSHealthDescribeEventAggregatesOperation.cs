using Amazon;
using Amazon.AWSHealth;
using Amazon.AWSHealth.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AWSHealthDescribeEventAggregatesOperation : Operation
    {
        public override string Name => "DescribeEventAggregates";

        public override string Description => "Returns the number of events of each event type (issue, scheduled change, and account notification). If no filter is specified, the counts of all events in each category are returned.";
 
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
                DescribeEventAggregatesRequest req = new DescribeEventAggregatesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeEventAggregates(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.EventAggregates)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}