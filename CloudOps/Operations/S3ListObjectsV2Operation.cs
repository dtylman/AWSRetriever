using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class S3ListObjectsV2Operation : Operation
    {
        public override string Name => "ListObjectsV2";

        public override string Description => "Returns some or all (up to 1000) of the objects in a bucket. You can use the request parameters as selection criteria to return a subset of the objects in a bucket. Note: ListObjectsV2 is the revised List Objects API and we recommend you use this revised API for new application development.";
 
        public override string RequestURI => "/{Bucket}?list-type=2";

        public override string Method => "GET";

        public override string ServiceName => "S3";

        public override string ServiceID => "S3";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonS3Client client = new AmazonS3Client(creds, region);
            ListObjectsV2Output resp = new ListObjectsV2Output();
            do
            {
                ListObjectsV2Request req = new ListObjectsV2Request
                {
                    ContinuationToken = resp.NextContinuationToken,
                    MaxKeys = maxItems
                };
                resp = client.ListObjectsV2(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.[Contents CommonPrefixes])
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextContinuationToken));
        }
    }
}