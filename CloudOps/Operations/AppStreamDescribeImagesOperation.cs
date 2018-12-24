using Amazon;
using Amazon.AppStream;
using Amazon.AppStream.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AppStreamDescribeImagesOperation : Operation
    {
        public override string Name => "DescribeImages";

        public override string Description => "Retrieves a list that describes one or more specified images, if the image names or image ARNs are provided. Otherwise, all images in the account are described.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AppStream";

        public override string ServiceID => "AppStream";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAppStreamClient client = new AmazonAppStreamClient(creds, region);
            DescribeImagesResult resp = new DescribeImagesResult();
            do
            {
                DescribeImagesRequest req = new DescribeImagesRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.DescribeImages(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}