using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.EC2
{
    public class DescribeBundleTasksOperation : Operation
    {
        public override string Name => "DescribeBundleTasks";

        public override string Description => "Describes one or more of your bundling tasks.  Completed bundle tasks are listed for only a limited time. If your bundle task is no longer in the list, you can still register an AMI from it. Just use RegisterImage with the Amazon S3 bucket name and image manifest name you provided to the bundle task. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Config config = new AmazonEC2Config();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonEC2Client client = new AmazonEC2Client(creds, config);
            
            DescribeBundleTasksResponse resp = new DescribeBundleTasksResponse();
            DescribeBundleTasksRequest req = new DescribeBundleTasksRequest
            {                    
                                    
            };
            resp = client.DescribeBundleTasks(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.BundleTasks)
            {
                AddObject(obj);
            }
            
        }
    }
}