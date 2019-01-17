using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;

namespace CloudOps.S3
{
    public class ListBucketsOperation : Operation
    {
        public override string Name => "ListBuckets";

        public override string Description => "Returns a list of all buckets owned by the authenticated sender of the request.";
 
        public override string RequestURI => "/";

        public override string Method => "GET";

        public override string ServiceName => "S3";

        public override string ServiceID => "S3";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonS3Config config = new AmazonS3Config();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonS3Client client = new AmazonS3Client(creds, config);
            
            ListBucketsResponse resp = new ListBucketsResponse();
            ListBucketsRequest req = new ListBucketsRequest
            {                    
                                    
            };
            resp = client.ListBuckets(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.Buckets)
            {
                AddObject(obj);
            }
            
        }
    }
}