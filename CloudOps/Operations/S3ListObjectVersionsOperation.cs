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
 
        public override string RequestURI => "/{Bucket}?versions";

        public override string Method => "GET";

        public override string ServiceName => "S3";

        public override string ServiceID => "S3";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonS3Client client = new AmazonS3Client(creds, region);
            ListObjectVersionsOutput resp = new ListObjectVersionsOutput();
            do
            {
                ListObjectVersionsRequest req = new ListObjectVersionsRequest
                {
                    [KeyMarker VersionIdMarker] = resp.[NextKeyMarker NextVersionIdMarker],
                    MaxKeys = maxItems
                };
                resp = client.ListObjectVersions(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.[Versions DeleteMarkers CommonPrefixes])
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.[NextKeyMarker NextVersionIdMarker]));
        }
    }
}