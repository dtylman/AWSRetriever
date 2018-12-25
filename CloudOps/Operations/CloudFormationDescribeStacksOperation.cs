using Amazon;
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudFormationDescribeStacksOperation : Operation
    {
        public override string Name => "DescribeStacks";

        public override string Description => "Returns the description for the specified stack; if no stack name was specified, then it returns the description for all the stacks created.  If the stack does not exist, an AmazonCloudFormationException is returned. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudFormation";

        public override string ServiceID => "CloudFormation";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudFormationClient client = new AmazonCloudFormationClient(creds, region);
            DescribeStacksOutput resp = new DescribeStacksOutput();
            do
            {
                DescribeStacksInput req = new DescribeStacksInput
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.DescribeStacks(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Stacks)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}