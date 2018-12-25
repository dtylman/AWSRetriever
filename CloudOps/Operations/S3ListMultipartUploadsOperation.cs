using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class S3ListMultipartUploadsOperation : Operation
    {
        public override string Name => "ListMultipartUploads";

        public override string Description => "This operation lists in-progress multipart uploads.";
 
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
                ListMultipartUploadsRequest req = new ListMultipartUploadsRequest
                {
                    KeyMarkerUploadIdMarker = resp.NextKeyMarkerNextUploadIdMarker
                    ,
                    MaxUploads = maxItems
                                        
                };

                resp = client.ListMultipartUploads(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextKeyMarkerNextUploadIdMarker));
        }
    }
}