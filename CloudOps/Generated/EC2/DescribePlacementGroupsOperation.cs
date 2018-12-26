using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.EC2
{
    public class DescribePlacementGroupsOperation : Operation
    {
        public override string Name => "DescribePlacementGroups";

        public override string Description => "Describes one or more of your placement groups. For more information, see Placement Groups in the Amazon Elastic Compute Cloud User Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribePlacementGroupsResponse resp = new DescribePlacementGroupsResponse();
            DescribePlacementGroupsRequest req = new DescribePlacementGroupsRequest
            {                    
                                    
            };
            resp = client.DescribePlacementGroups(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.PlacementGroups)
            {
                AddObject(obj);
            }
            
        }
    }
}