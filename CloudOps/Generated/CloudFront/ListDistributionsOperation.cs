using Amazon;
using Amazon.CloudFront;
using Amazon.CloudFront.Model;
using Amazon.Runtime;

namespace CloudOps.CloudFront
{
    public class ListDistributionsOperation : Operation
    {
        public override string Name => "ListDistributions";

        public override string Description => "List distributions. ";
 
        public override string RequestURI => "/2018-11-05/distribution";

        public override string Method => "GET";

        public override string ServiceName => "CloudFront";

        public override string ServiceID => "CloudFront";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudFrontConfig config = new AmazonCloudFrontConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonCloudFrontClient client = new AmazonCloudFrontClient(creds, config);
            
            ListDistributionsResponse resp = new ListDistributionsResponse();
            do
            {
                ListDistributionsRequest req = new ListDistributionsRequest
                {
                    Marker = resp.DistributionList.NextMarker
                    ,
                    MaxItems = maxItems.ToString()
                                        
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