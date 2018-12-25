using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class EC2DescribePlacementGroupsOperation : Operation
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
            DescribePlacementGroupsResult resp = new DescribePlacementGroupsResult();
            do
            {
                DescribePlacementGroupsRequest req = new DescribePlacementGroupsRequest
                {
                    &lt;nil&gt; = resp.&lt;nil&gt;
                                        
                };

                resp = client.DescribePlacementGroups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.PlacementGroups)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.&lt;nil&gt;));
        }
    }
}