using Amazon;
using Amazon.CloudFront;
using Amazon.CloudFront.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudFrontListInvalidationsOperation : Operation
    {
        public override string Name => "ListInvalidations";

        public override string Description => "Lists invalidation batches. ";
 
        public override string RequestURI => "/2018-11-05/distribution/{DistributionId}/invalidation";

        public override string Method => "GET";

        public override string ServiceName => "CloudFront";

        public override string ServiceID => "CloudFront";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudFrontClient client = new AmazonCloudFrontClient(creds, region);
            ListInvalidationsResult resp = new ListInvalidationsResult();
            do
            {
                ListInvalidationsRequest req = new ListInvalidationsRequest
                {
                    Marker = resp.InvalidationList.NextMarker,
                    MaxItems = maxItems
                };
                resp = client.ListInvalidations(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.InvalidationList.Items)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.InvalidationList.NextMarker));
        }
    }
}