using Amazon;
using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;
using Amazon.Runtime;

namespace CloudOps.ElasticLoadBalancing
{
    public class DescribeLoadBalancersOperation : Operation
    {
        public override string Name => "DescribeLoadBalancers";

        public override string Description => "Describes the specified the load balancers. If no load balancers are specified, the call describes all of your load balancers.";
 
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
            
            DescribeLoadBalancersResponse resp = new DescribeLoadBalancersResponse();
            do
            {
                DescribeLoadBalancersRequest req = new DescribeLoadBalancersRequest
                {
                    Marker = resp.NextMarker
                                        
                };

                resp = client.DescribeLoadBalancers(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.LoadBalancerDescriptions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));
        }
    }
}