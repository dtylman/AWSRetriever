using Amazon;
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudTrailLookupEventsOperation : Operation
    {
        public override string Name => "LookupEvents";

        public override string Description => "Looks up management events captured by CloudTrail. Events for a region can be looked up in that region during the last 90 days. Lookup supports the following attributes:   AWS access key   Event ID   Event name   Event source   Read only   Resource name   Resource type   User name   All attributes are optional. The default number of results returned is 50, with a maximum of 50 possible. The response includes a token that you can use to get the next page of results.  The rate of lookup requests is limited to one per second per account. If this limit is exceeded, a throttling error occurs.   Events that occurred during the selected time range will not be available for lookup if CloudTrail logging was not enabled when the events occurred. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudTrail";

        public override string ServiceID => "CloudTrail";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudTrailClient client = new AmazonCloudTrailClient(creds, region);
            LookupEventsResponse resp = new LookupEventsResponse();
            do
            {
                LookupEventsRequest req = new LookupEventsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.LookupEvents(req);
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