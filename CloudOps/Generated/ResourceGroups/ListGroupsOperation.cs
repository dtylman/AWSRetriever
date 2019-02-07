using Amazon;
using Amazon.ResourceGroups;
using Amazon.ResourceGroups.Model;
using Amazon.Runtime;

namespace CloudOps.ResourceGroups
{
    public class ListGroupsOperation : Operation
    {
        public override string Name => "ListGroups";

        public override string Description => "Returns a list of existing resource groups in your account.";
 
        public override string RequestURI => "/groups-list";

        public override string Method => "POST";

        public override string ServiceName => "ResourceGroups";

        public override string ServiceID => "Resource Groups";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonResourceGroupsConfig config = new AmazonResourceGroupsConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonResourceGroupsClient client = new AmazonResourceGroupsClient(creds, config);
            
            ListGroupsResponse resp = new ListGroupsResponse();
            do
            {
                ListGroupsRequest req = new ListGroupsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListGroups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.GroupIdentifiers)
                {
                    AddObject(obj);
                }                               
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}