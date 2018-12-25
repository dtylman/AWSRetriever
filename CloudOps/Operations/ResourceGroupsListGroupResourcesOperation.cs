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
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "ResourceGroups";

        public override string ServiceID => "Resource Groups";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonResourceGroupsClient client = new AmazonResourceGroupsClient(creds, region);
            Response resp = new Response();
            do
            {
                ListGroupResourcesRequest req = new ListGroupResourcesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListGroupResources(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}