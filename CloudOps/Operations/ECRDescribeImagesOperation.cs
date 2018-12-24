using Amazon;
using Amazon.ECR;
using Amazon.ECR.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ECRDescribeImagesOperation : Operation
    {
        public override string Name => "DescribeImages";

        public override string Description => "Returns metadata about the images in a repository, including image size, image tags, and creation date.  Beginning with Docker version 1.9, the Docker client compresses image layers before pushing them to a V2 Docker registry. The output of the docker images command shows the uncompressed image size, so it may return a larger image size than the image sizes returned by DescribeImages. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ECR";

        public override string ServiceID => "ECR";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonECRClient client = new AmazonECRClient(creds, region);
            DescribeImagesResponse resp = new DescribeImagesResponse();
            do
            {
                DescribeImagesRequest req = new DescribeImagesRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.DescribeImages(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.imageDetails)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}