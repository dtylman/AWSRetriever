using Amazon;
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;
using Amazon.Runtime;

namespace CloudOps.CloudFormation
{
    public class DescribeStackEventsOperation : Operation
    {
        public override string Name => "DescribeStackEvents";

        public override string Description => "Returns all stack related events for a specified stack in reverse chronological order. For more information about a stack&#39;s event history, go to Stacks in the AWS CloudFormation User Guide.  You can list events for stacks that have failed to create or have been deleted by specifying the unique stack identifier (stack ID). ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudFormation";

        public override string ServiceID => "CloudFormation";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudFormationConfig config = new AmazonCloudFormationConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonCloudFormationClient client = new AmazonCloudFormationClient(creds, config);
            
            DescribeStackEventsResponse resp = new DescribeStackEventsResponse();
            do
            {
                DescribeStackEventsRequest req = new DescribeStackEventsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.DescribeStackEvents(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.StackEvents)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}