using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class EC2DescribeExportTasksOperation : Operation
    {
        public override string Name => "DescribeExportTasks";

        public override string Description => "Describes one or more of your export tasks.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribeExportTasksResult resp = new DescribeExportTasksResult();
            DescribeExportTasksRequest req = new DescribeExportTasksRequest
            {                    
                                    
            };
            resp = client.DescribeExportTasks(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.ExportTasks)
            {
                AddObject(obj);
            }
            
        }
    }
}