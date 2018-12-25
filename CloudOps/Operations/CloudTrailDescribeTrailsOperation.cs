using Amazon;
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudTrailDescribeTrailsOperation : Operation
    {
        public override string Name => "DescribeTrails";

        public override string Description => "Retrieves settings for the trail associated with the current region for your account.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudTrail";

        public override string ServiceID => "CloudTrail";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudTrailClient client = new AmazonCloudTrailClient(creds, region);
            DescribeTrailsResponse resp = new DescribeTrailsResponse();
            DescribeTrailsRequest req = new DescribeTrailsRequest
            {                    
                                    
            };
            resp = client.DescribeTrails(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.trailList)
            {
                AddObject(obj);
            }
            
        }
    }
}