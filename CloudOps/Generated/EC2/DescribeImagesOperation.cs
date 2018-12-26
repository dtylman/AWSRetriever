using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.EC2
{
    public class DescribeImagesOperation : Operation
    {
        public override string Name => "DescribeImages";

        public override string Description => "Describes one or more of the images (AMIs, AKIs, and ARIs) available to you. Images available to you include public images, private images that you own, and private images owned by other AWS accounts but for which you have explicit launch permissions.  Deregistered images are included in the returned results for an unspecified interval after deregistration. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribeImagesResponse resp = new DescribeImagesResponse();
            DescribeImagesRequest req = new DescribeImagesRequest
            {                    
                                    
            };
            resp = client.DescribeImages(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.Images)
            {
                AddObject(obj);
            }
            
        }
    }
}