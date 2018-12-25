using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class S3ListObjectVersionsOperation : Operation
    {
        public override string Name => "ListObjectVersions";

        public override string Description => "Returns metadata about all of the versions of objects in a bucket.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "S3";

        public override string ServiceID => "S3";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonS3Client client = new AmazonS3Client(creds, region);
            Response resp = new Response();
            do
            {
                ListObjectVersionsRequest req = new ListObjectVersionsRequest
                {
                    KeyMarkerVersionIdMarker = resp.NextKeyMarkerNextVersionIdMarker
                    ,
                    MaxKeys = maxItems
                                        
                };

                resp = client.ListObjectVersions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextKeyMarkerNextVersionIdMarker));
        }
    }
}