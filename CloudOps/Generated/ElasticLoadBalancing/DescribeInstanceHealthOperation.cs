using Amazon;
using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;
using Amazon.Runtime;

namespace CloudOps.ElasticLoadBalancing
{
    public class DescribeInstanceHealthOperation : Operation
    {
        public override string Name => "DescribeInstanceHealth";

        public override string Description => "Describes the state of the specified instances with respect to the specified load balancer. If no instances are specified, the call describes the state of all instances that are currently registered with the load balancer. If instances are specified, their state is returned even if they are no longer registered with the load balancer. The state of terminated instances is not returned.";
 
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
            
            DescribeInstanceHealthResponse resp = new DescribeInstanceHealthResponse();
            DescribeInstanceHealthRequest req = new DescribeInstanceHealthRequest
            {                    
                                    
            };
            resp = client.DescribeInstanceHealth(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.InstanceStates)
            {
                AddObject(obj);
            }
            
        }
    }
}