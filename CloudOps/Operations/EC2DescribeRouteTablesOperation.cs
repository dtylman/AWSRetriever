using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class EC2DescribeRouteTablesOperation : Operation
    {
        public override string Name => "DescribeRouteTables";

        public override string Description => "Describes one or more of your route tables. Each subnet in your VPC must be associated with a route table. If a subnet is not explicitly associated with any route table, it is implicitly associated with the main route table. This command does not return the subnet ID for implicit associations. For more information, see Route Tables in the Amazon Virtual Private Cloud User Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribeRouteTablesResultResponse resp = new DescribeRouteTablesResultResponse();
            do
            {
                DescribeRouteTablesRequest req = new DescribeRouteTablesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeRouteTables(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.RouteTables)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}