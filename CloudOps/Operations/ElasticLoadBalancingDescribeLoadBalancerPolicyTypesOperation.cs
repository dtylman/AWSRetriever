using Amazon;
using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElasticLoadBalancingDescribeLoadBalancerPolicyTypesOperation : Operation
    {
        public override string Name => "DescribeLoadBalancerPolicyTypes";

        public override string Description => "Describes the specified load balancer policy types or all load balancer policy types. The description of each type indicates how it can be used. For example, some policies can be used only with layer 7 listeners, some policies can be used only with layer 4 listeners, and some policies can be used only with your EC2 instances. You can use CreateLoadBalancerPolicy to create a policy configuration for any of these policy types. Then, depending on the policy type, use either SetLoadBalancerPoliciesOfListener or SetLoadBalancerPoliciesForBackendServer to set the policy.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElasticLoadBalancing";

        public override string ServiceID => "Elastic Load Balancing";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticLoadBalancingClient client = new AmazonElasticLoadBalancingClient(creds, region);
            DescribeLoadBalancerPolicyTypesOutput resp = new DescribeLoadBalancerPolicyTypesOutput();
            do
            {
                DescribeLoadBalancerPolicyTypesInput req = new DescribeLoadBalancerPolicyTypesInput
                {
                    &lt;nil&gt; = resp.&lt;nil&gt;
                                        
                };

                resp = client.DescribeLoadBalancerPolicyTypes(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.PolicyTypeDescriptions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.&lt;nil&gt;));
        }
    }
}