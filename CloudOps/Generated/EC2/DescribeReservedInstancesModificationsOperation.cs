using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.EC2
{
    public class DescribeReservedInstancesModificationsOperation : Operation
    {
        public override string Name => "DescribeReservedInstancesModifications";

        public override string Description => "Describes the modifications made to your Reserved Instances. If no parameter is specified, information about all your Reserved Instances modification requests is returned. If a modification ID is specified, only information about the specific modification is returned. For more information, see Modifying Reserved Instances in the Amazon Elastic Compute Cloud User Guide.";
 
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
            
            DescribeReservedInstancesModificationsResponse resp = new DescribeReservedInstancesModificationsResponse();
            do
            {
                DescribeReservedInstancesModificationsRequest req = new DescribeReservedInstancesModificationsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.DescribeReservedInstancesModifications(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ReservedInstancesModifications)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}