using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.EC2
{
    public class DescribeConversionTasksOperation : Operation
    {
        public override string Name => "DescribeConversionTasks";

        public override string Description => "Describes one or more of your conversion tasks. For more information, see the VM Import/Export User Guide. For information about the import manifest referenced by this API action, see VM Import Manifest.";
 
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
            
            DescribeConversionTasksResponse resp = new DescribeConversionTasksResponse();
            DescribeConversionTasksRequest req = new DescribeConversionTasksRequest
            {                    
                                    
            };
            resp = client.DescribeConversionTasks(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.ConversionTasks)
            {
                AddObject(obj);
            }
            
        }
    }
}