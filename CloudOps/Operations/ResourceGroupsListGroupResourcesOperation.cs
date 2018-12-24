using Amazon;
using Amazon.ResourceGroups;
using Amazon.ResourceGroups.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ResourceGroupsListGroupResourcesOperation : Operation
    {
        public override string Name => "ListGroupResources";

        public override string Description => "Returns a list of ARNs of resources that are members of a specified resource group.";
 
        public override string RequestURI => "/groups/{GroupName}/resource-identifiers-list";

        public override string Method => "POST";

        public override string ServiceName => "ResourceGroups";

        public override string ServiceID => "Resource Groups";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonResourceGroupsClient client = new AmazonResourceGroupsClient(creds, region);
            ListGroupResourcesOutput resp = new ListGroupResourcesOutput();
            do
            {
                ListGroupResourcesInput req = new ListGroupResourcesInput
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListGroupResources(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}