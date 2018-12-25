using Amazon;
using Amazon.AWSHealth;
using Amazon.AWSHealth.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AWSHealthDescribeEventTypesOperation : Operation
    {
        public override string Name => "DescribeEventTypes";

        public override string Description => "Returns the event types that meet the specified filter criteria. If no filter criteria are specified, all event types are returned, in no particular order.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AWSHealth";

        public override string ServiceID => "Health";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAWSHealthClient client = new AmazonAWSHealthClient(creds, region);
            DescribeEventTypesResponse resp = new DescribeEventTypesResponse();
            do
            {
                DescribeEventTypesRequest req = new DescribeEventTypesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeEventTypes(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.EventTypes)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}