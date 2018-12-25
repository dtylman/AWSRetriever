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
            ListDistributionsResultResponse resp = new ListDistributionsResultResponse();
            do
            {
                ListDistributionsRequest req = new ListDistributionsRequest
                {
                    Marker = resp.DistributionListNextMarker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListDistributions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DistributionListItems)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.DistributionListNextMarker));
        }
    }
}