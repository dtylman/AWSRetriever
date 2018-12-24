using Amazon;
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElasticLoadBalancingV2DescribeTargetGroupsOperation : Operation
    {
        public override string Name => "DescribeTargetGroups";

        public override string Description => "Describes the specified target groups or all of your target groups. By default, all target groups are described. Alternatively, you can specify one of the following to filter the results: the ARN of the load balancer, the names of one or more target groups, or the ARNs of one or more target groups. To describe the targets for a target group, use DescribeTargetHealth. To describe the attributes of a target group, use DescribeTargetGroupAttributes.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElasticLoadBalancingV2";

        public override string ServiceID => "Elastic Load Balancing v2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticLoadBalancingV2Client client = new AmazonElasticLoadBalancingV2Client(creds, region);
            DescribeTargetGroupsOutput resp = new DescribeTargetGroupsOutput();
            do
            {
                DescribeTargetGroupsInput req = new DescribeTargetGroupsInput
                {
                    Marker = resp.NextMarker,
                    &lt;nil&gt; = maxItems
                };
                resp = client.DescribeTargetGroups(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.TargetGroups)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));
        }
    }
}