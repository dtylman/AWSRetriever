using Amazon;
using Amazon.CloudFront;
using Amazon.CloudFront.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudFrontListCloudFrontOriginAccessIdentitiesOperation : Operation
    {
        public override string Name => "ListCloudFrontOriginAccessIdentities";

        public override string Description => "Lists origin access identities.";
 
        public override string RequestURI => "/2018-11-05/origin-access-identity/cloudfront";

        public override string Method => "GET";

        public override string ServiceName => "CloudFront";

        public override string ServiceID => "CloudFront";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudFrontClient client = new AmazonCloudFrontClient(creds, region);
            ListCloudFrontOriginAccessIdentitiesResultResponse resp = new ListCloudFrontOriginAccessIdentitiesResultResponse();
            do
            {
                ListCloudFrontOriginAccessIdentitiesRequest req = new ListCloudFrontOriginAccessIdentitiesRequest
                {
                    Marker = resp.CloudFrontOriginAccessIdentityListNextMarker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListCloudFrontOriginAccessIdentities(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.CloudFrontOriginAccessIdentityListItems)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.CloudFrontOriginAccessIdentityListNextMarker));
        }
    }
}