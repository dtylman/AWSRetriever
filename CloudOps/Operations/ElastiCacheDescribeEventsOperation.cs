using Amazon;
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElastiCacheDescribeEventsOperation : Operation
    {
        public override string Name => "DescribeEvents";

        public override string Description => "Returns events related to clusters, cache security groups, and cache parameter groups. You can obtain events specific to a particular cluster, cache security group, or cache parameter group by providing the name as a parameter. By default, only the events occurring within the last hour are returned; however, you can retrieve up to 14 days&#39; worth of events if necessary.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElastiCache";

        public override string ServiceID => "ElastiCache";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElastiCacheClient client = new AmazonElastiCacheClient(creds, region);
            EventsMessageResponse resp = new EventsMessageResponse();
            do
            {
                DescribeEventsMessageRequest req = new DescribeEventsMessageRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeEvents(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Events)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}