using Amazon;
using Amazon.ResourceGroups;
using Amazon.ResourceGroups.Model;
using Amazon.Runtime;

namespace CloudOps.ResourceGroups
{
    public class SearchResourcesOperation : Operation
    {
        public override string Name => "SearchResources";

        public override string Description => "Returns a list of AWS resource identifiers that matches a specified query. The query uses the same format as a resource query in a CreateGroup or UpdateGroupQuery operation.";
 
        public override string RequestURI => "/resources/search";

        public override string Method => "POST";

        public override string ServiceName => "ResourceGroups";

        public override string ServiceID => "Resource Groups";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonResourceGroupsConfig config = new AmazonResourceGroupsConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonResourceGroupsClient client = new AmazonResourceGroupsClient(creds, config);
            
            SearchResourcesResponse resp = new SearchResourcesResponse();
            do
            {
                SearchResourcesRequest req = new SearchResourcesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.SearchResources(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ResourceIdentifiers)
                {
                    AddObject(obj);
                }
                
                foreach (var obj in resp.QueryErrors)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}