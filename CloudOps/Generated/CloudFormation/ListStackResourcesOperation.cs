using Amazon;
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;
using Amazon.Runtime;

namespace CloudOps.CloudFormation
{
    public class ListStackResourcesOperation : Operation
    {
        public override string Name => "ListStackResources";

        public override string Description => "Returns descriptions of all resources of the specified stack. For deleted stacks, ListStackResources returns resource information for up to 90 days after the stack has been deleted.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudFormation";

        public override string ServiceID => "CloudFormation";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudFormationClient client = new AmazonCloudFormationClient(creds, region);
            ListStackResourcesResponse resp = new ListStackResourcesResponse();
            do
            {
                ListStackResourcesRequest req = new ListStackResourcesRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListStackResources(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.StackResourceSummaries)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}