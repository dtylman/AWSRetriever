using Amazon;
using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElasticLoadBalancingDescribeLoadBalancersOperation : Operation
    {
        public override string Name => "DescribeLoadBalancers";

        public override string Description => "Describes the specified the load balancers. If no load balancers are specified, the call describes all of your load balancers.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElasticLoadBalancing";

        public override string ServiceID => "Elastic Load Balancing";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticLoadBalancingClient client = new AmazonElasticLoadBalancingClient(creds, region);
            DescribeAccessPointsResponse resp = new DescribeAccessPointsResponse();
            do
            {
                DescribeAccessPointsRequest req = new DescribeAccessPointsRequest
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