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
 
        public override string RequestURI => "/{Bucket}?uploads";

        public override string Method => "GET";

        public override string ServiceName => "S3";

        public override string ServiceID => "S3";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonS3Client client = new AmazonS3Client(creds, region);
            ListMultipartUploadsOutput resp = new ListMultipartUploadsOutput();
            do
            {
                ListMultipartUploadsRequest req = new ListMultipartUploadsRequest
                {
                    [KeyMarker UploadIdMarker] = resp.[NextKeyMarker NextUploadIdMarker],
                    MaxUploads = maxItems
                };
                resp = client.ListMultipartUploads(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.[Uploads CommonPrefixes])
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.[NextKeyMarker NextUploadIdMarker]));
        }
    }
}