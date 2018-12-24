using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class S3ListPartsOperation : Operation
    {
        public override string Name => "ListParts";

        public override string Description => "Lists the parts that have been uploaded for a specific multipart upload.";
 
        public override string RequestURI => "/{Bucket}/{Key&#43;}";

        public override string Method => "GET";

        public override string ServiceName => "S3";

        public override string ServiceID => "S3";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonS3Client client = new AmazonS3Client(creds, region);
            ListPartsOutput resp = new ListPartsOutput();
            do
            {
                ListPartsRequest req = new ListPartsRequest
                {
                    PartNumberMarker = resp.NextPartNumberMarker,
                    MaxParts = maxItems
                };
                resp = client.ListParts(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Parts)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextPartNumberMarker));
        }
    }
}