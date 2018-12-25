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
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "CloudFront";

        public override string ServiceID => "CloudFront";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudFrontClient client = new AmazonCloudFrontClient(creds, region);
            Response resp = new Response();
            do
            {
                ListInvalidationsRequest req = new ListInvalidationsRequest
                {
                    Marker = resp.InvalidationListNextMarker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListInvalidations(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.InvalidationListItems)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.InvalidationListNextMarker));
        }
    }
}