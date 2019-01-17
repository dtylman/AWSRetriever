using Amazon;
using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;
using Amazon.Runtime;

namespace CloudOps.ElasticLoadBalancing
{
    public class DescribeLoadBalancerPoliciesOperation : Operation
    {
        public override string Name => "DescribeLoadBalancerPolicies";

        public override string Description => "Describes the specified policies. If you specify a load balancer name, the action returns the descriptions of all policies created for the load balancer. If you specify a policy name associated with your load balancer, the action returns the description of that policy. If you don&#39;t specify a load balancer name, the action returns descriptions of the specified sample policies, or descriptions of all sample policies. The names of the sample policies have the ELBSample- prefix.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElasticLoadBalancing";

        public override string ServiceID => "Elastic Load Balancing";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticLoadBalancingConfig config = new AmazonElasticLoadBalancingConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonElasticLoadBalancingClient client = new AmazonElasticLoadBalancingClient(creds, config);
            
            DescribeLoadBalancerPoliciesResponse resp = new DescribeLoadBalancerPoliciesResponse();
            DescribeLoadBalancerPoliciesRequest req = new DescribeLoadBalancerPoliciesRequest
            {                    
                                    
            };
            resp = client.DescribeLoadBalancerPolicies(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.PolicyDescriptions)
            {
                AddObject(obj);
            }
            
        }
    }
}