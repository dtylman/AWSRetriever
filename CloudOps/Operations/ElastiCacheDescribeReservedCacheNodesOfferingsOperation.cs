using Amazon;
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElastiCacheDescribeReservedCacheNodesOfferingsOperation : Operation
    {
        public override string Name => "DescribeReservedCacheNodesOfferings";

        public override string Description => "Lists available reserved cache node offerings.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElastiCache";

        public override string ServiceID => "ElastiCache";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElastiCacheClient client = new AmazonElastiCacheClient(creds, region);
            ReservedCacheNodesOfferingMessageResponse resp = new ReservedCacheNodesOfferingMessageResponse();
            do
            {
                DescribeReservedCacheNodesOfferingsMessageRequest req = new DescribeReservedCacheNodesOfferingsMessageRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeReservedCacheNodesOfferings(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ReservedCacheNodesOfferings)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}