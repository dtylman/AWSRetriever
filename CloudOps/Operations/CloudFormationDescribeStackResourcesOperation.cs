using Amazon;
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudFormationDescribeStackResourcesOperation : Operation
    {
        public override string Name => "DescribeStackResources";

        public override string Description => "Returns AWS resource descriptions for running and deleted stacks. If StackName is specified, all the associated resources that are part of the stack are returned. If PhysicalResourceId is specified, the associated resources of the stack that the resource belongs to are returned.  Only the first 100 resources will be returned. If your stack has more resources than this, you should use ListStackResources instead.  For deleted stacks, DescribeStackResources returns resource information for up to 90 days after the stack has been deleted. You must specify either StackName or PhysicalResourceId, but not both. In addition, you can specify LogicalResourceId to filter the returned result. For more information about resources, the LogicalResourceId and PhysicalResourceId, go to the AWS CloudFormation User Guide.  A ValidationError is returned if you specify both StackName and PhysicalResourceId in the same request. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudFormation";

        public override string ServiceID => "CloudFormation";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudFormationClient client = new AmazonCloudFormationClient(creds, region);
            DescribeStackResourcesResponse resp = new DescribeStackResourcesResponse();
            DescribeStackResourcesRequest req = new DescribeStackResourcesRequest
            {                    
                                    
            };
            resp = client.DescribeStackResources(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.StackResources)
            {
                AddObject(obj);
            }
            
        }
    }
}