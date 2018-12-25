using Amazon;
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AutoScalingDescribeLaunchConfigurationsOperation : Operation
    {
        public override string Name => "DescribeLaunchConfigurations";

        public override string Description => "Describes one or more launch configurations.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AutoScaling";

        public override string ServiceID => "Auto Scaling";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAutoScalingClient client = new AmazonAutoScalingClient(creds, region);
            LaunchConfigurationsTypeResponse resp = new LaunchConfigurationsTypeResponse();
            do
            {
                LaunchConfigurationNamesTypeRequest req = new LaunchConfigurationNamesTypeRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeLaunchConfigurations(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.LaunchConfigurations)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}