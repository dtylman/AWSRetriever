using Amazon;
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;
using Amazon.Runtime;

namespace CloudOps.CloudFormation
{
    public class DescribeStackResourceDriftsOperation : Operation
    {
        public override string Name => "DescribeStackResourceDrifts";

        public override string Description => "Returns drift information for the resources that have been checked for drift in the specified stack. This includes actual and expected configuration values for resources where AWS CloudFormation detects configuration drift. For a given stack, there will be one StackResourceDrift for each stack resource that has been checked for drift. Resources that have not yet been checked for drift are not included. Resources that do not currently support drift detection are not checked, and so not included. For a list of resources that support drift detection, see Resources that Support Drift Detection. Use DetectStackResourceDrift to detect drift on individual resources, or DetectStackDrift to detect drift on all supported resources for a given stack.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudFormation";

        public override string ServiceID => "CloudFormation";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudFormationClient client = new AmazonCloudFormationClient(creds, region);
            DescribeStackResourceDriftsResponse resp = new DescribeStackResourceDriftsResponse();
            do
            {
                DescribeStackResourceDriftsRequest req = new DescribeStackResourceDriftsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeStackResourceDrifts(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.StackResourceDrifts)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}