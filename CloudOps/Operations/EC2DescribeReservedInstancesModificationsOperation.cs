using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class EC2DescribeReservedInstancesModificationsOperation : Operation
    {
        public override string Name => "DescribeReservedInstancesModifications";

        public override string Description => "Describes the modifications made to your Reserved Instances. If no parameter is specified, information about all your Reserved Instances modification requests is returned. If a modification ID is specified, only information about the specific modification is returned. For more information, see Modifying Reserved Instances in the Amazon Elastic Compute Cloud User Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribeReservedInstancesModificationsResult resp = new DescribeReservedInstancesModificationsResult();
            do
            {
                DescribeReservedInstancesModificationsRequest req = new DescribeReservedInstancesModificationsRequest
                {
                    NextToken = resp.NextToken,
                    &lt;nil&gt; = maxItems
                };
                resp = client.DescribeReservedInstancesModifications(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.ReservedInstancesModifications)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}