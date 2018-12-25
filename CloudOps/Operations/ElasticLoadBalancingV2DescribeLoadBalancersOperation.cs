using Amazon;
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElasticLoadBalancingV2DescribeLoadBalancersOperation : Operation
    {
        public override string Name => "DescribeLoadBalancers";

        public override string Description => "Describes the specified load balancers or all of your load balancers. To describe the listeners for a load balancer, use DescribeListeners. To describe the attributes for a load balancer, use DescribeLoadBalancerAttributes.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElasticLoadBalancingV2";

        public override string ServiceID => "Elastic Load Balancing v2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticLoadBalancingV2Client client = new AmazonElasticLoadBalancingV2Client(creds, region);
            DescribeLoadBalancersOutput resp = new DescribeLoadBalancersOutput();
            do
            {
                DescribeLoadBalancersInput req = new DescribeLoadBalancersInput
                {
                    Marker = resp.NextMarker
                                        
                };

                resp = client.DescribeLoadBalancers(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.LoadBalancers)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));
        }
    }
}