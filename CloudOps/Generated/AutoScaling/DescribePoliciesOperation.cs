using Amazon;
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;
using Amazon.Runtime;

namespace CloudOps.AutoScaling
{
    public class DescribePoliciesOperation : Operation
    {
        public override string Name => "DescribePolicies";

        public override string Description => "Describes the policies for the specified Auto Scaling group.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AutoScaling";

        public override string ServiceID => "Auto Scaling";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAutoScalingConfig config = new AmazonAutoScalingConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonAutoScalingClient client = new AmazonAutoScalingClient(creds, config);
            
            DescribePoliciesResponse resp = new DescribePoliciesResponse();
            do
            {
                DescribePoliciesRequest req = new DescribePoliciesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribePolicies(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ScalingPolicies)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}