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
                ListObjectsV2Request req = new ListObjectsV2Request
                {
                    ContinuationToken = resp.NextContinuationToken
                    ,
                    MaxKeys = maxItems
                                        
                };

                resp = client.ListObjectsV2(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextContinuationToken));
        }
    }
}