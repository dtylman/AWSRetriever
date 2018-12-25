using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class EC2DescribeReservedInstancesListingsOperation : Operation
    {
        public override string Name => "DescribeReservedInstancesListings";

        public override string Description => "Describes your account&#39;s Reserved Instance listings in the Reserved Instance Marketplace. The Reserved Instance Marketplace matches sellers who want to resell Reserved Instance capacity that they no longer need with buyers who want to purchase additional capacity. Reserved Instances bought and sold through the Reserved Instance Marketplace work like any other Reserved Instances. As a seller, you choose to list some or all of your Reserved Instances, and you specify the upfront price to receive for them. Your Reserved Instances are then listed in the Reserved Instance Marketplace and are available for purchase. As a buyer, you specify the configuration of the Reserved Instance to purchase, and the Marketplace matches what you&#39;re searching for with what&#39;s available. The Marketplace first sells the lowest priced Reserved Instances to you, and continues to sell available Reserved Instance listings to you until your demand is met. You are charged based on the total price of all of the listings that you purchase. For more information, see Reserved Instance Marketplace in the Amazon Elastic Compute Cloud User Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribeReservedInstancesListingsResult resp = new DescribeReservedInstancesListingsResult();
            do
            {
                DescribeReservedInstancesListingsRequest req = new DescribeReservedInstancesListingsRequest
                {
                    &lt;nil&gt; = resp.&lt;nil&gt;
                                        
                };

                resp = client.DescribeReservedInstancesListings(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ReservedInstancesListings)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.&lt;nil&gt;));
        }
    }
}