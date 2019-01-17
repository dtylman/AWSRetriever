using Amazon;
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;
using Amazon.Runtime;

namespace CloudOps.CloudFormation
{
    public class ListStacksOperation : Operation
    {
        public override string Name => "ListStacks";

        public override string Description => "Returns the summary information for stacks whose status matches the specified StackStatusFilter. Summary information for stacks that have been deleted is kept for 90 days after the stack is deleted. If no StackStatusFilter is specified, summary information for all stacks is returned (including existing stacks and stacks that have been deleted).";
 
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
            
            ListStacksResponse resp = new ListStacksResponse();
            do
            {
                ListStacksRequest req = new ListStacksRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListStacks(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.StackSummaries)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}