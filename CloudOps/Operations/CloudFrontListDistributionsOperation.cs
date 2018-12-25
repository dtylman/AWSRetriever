using Amazon;
using Amazon.CloudFront;
using Amazon.CloudFront.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudFrontListDistributionsOperation : Operation
    {
        public override string Name => "ListDistributions";

        public override string Description => "List distributions. ";
 
        public override string RequestURI => "/2018-11-05/distribution";

        public override string Method => "GET";

        public override string ServiceName => "CloudFront";

        public override string ServiceID => "CloudFront";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudFrontClient client = new AmazonCloudFrontClient(creds, region);
            ListDistributionsResult resp = new ListDistributionsResult();
            do
            {
                ListDistributionsRequest req = new ListDistributionsRequest
                {
                    Marker = resp.DistributionList.NextMarker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListDistributions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DistributionList.Items)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.DistributionList.NextMarker));
        }
    }
}