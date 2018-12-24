using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class S3ListObjectsOperation : Operation
    {
        public override string Name => "ListObjects";

        public override string Description => "Returns some or all (up to 1000) of the objects in a bucket. You can use the request parameters as selection criteria to return a subset of the objects in a bucket.";
 
        public override string RequestURI => "/{Bucket}";

        public override string Method => "GET";

        public override string ServiceName => "S3";

        public override string ServiceID => "S3";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonS3Client client = new AmazonS3Client(creds, region);
            ListObjectsOutput resp = new ListObjectsOutput();
            do
            {
                ListObjectsRequest req = new ListObjectsRequest
                {
                    Marker = resp.NextMarker || Contents[-1].Key,
                    MaxKeys = maxItems
                };
                resp = client.ListObjects(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.[Contents CommonPrefixes])
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextMarker || Contents[-1].Key));
        }
    }
}