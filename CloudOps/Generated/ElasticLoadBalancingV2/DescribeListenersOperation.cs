using Amazon;
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;
using Amazon.Runtime;

namespace CloudOps.ElasticLoadBalancingV2
{
    public class DescribeListenersOperation : Operation
    {
        public override string Name => "DescribeListeners";

        public override string Description => "Describes the specified listeners or the listeners for the specified Application Load Balancer or Network Load Balancer. You must specify either a load balancer or one or more listeners.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElasticLoadBalancingV2";

        public override string ServiceID => "Elastic Load Balancing v2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticLoadBalancingV2Client client = new AmazonElasticLoadBalancingV2Client(creds, region);
            DescribeListenersResponse resp = new DescribeListenersResponse();
            do
            {
                DescribeListenersRequest req = new DescribeListenersRequest
                {
                    Marker = resp.NextMarker
                                        
                };

                resp = client.DescribeListeners(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Listeners)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));
        }
    }
}