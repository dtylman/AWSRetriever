using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class S3ListBucketsOperation : Operation
    {
        public override string Name => "ListBuckets";

        public override string Description => "Returns a list of all buckets owned by the authenticated sender of the request.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "S3";

        public override string ServiceID => "S3";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonS3Client client = new AmazonS3Client(creds, region);
            Response resp = new Response();
            Request req = new Request
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