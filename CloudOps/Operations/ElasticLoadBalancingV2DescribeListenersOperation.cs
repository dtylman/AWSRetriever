using Amazon;
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElasticLoadBalancingV2DescribeListenersOperation : Operation
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
            DescribeListenersOutput resp = new DescribeListenersOutput();
            do
            {
                DescribeListenersInput req = new DescribeListenersInput
                {
                    Marker = resp.NextMarker,
                    &lt;nil&gt; = maxItems
                };
                resp = client.DescribeListeners(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Listeners)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));
        }
    }
}