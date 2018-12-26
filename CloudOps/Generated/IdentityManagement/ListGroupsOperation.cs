using Amazon;
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;

namespace CloudOps.IdentityManagement
{
    public class ListGroupsOperation : Operation
    {
        public override string Name => "ListGroups";

        public override string Description => "Lists the IAM groups that have the specified path prefix.  You can paginate the results using the MaxItems and Marker parameters.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "IdentityManagement";

        public override string ServiceID => "IAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIdentityManagementServiceClient client = new AmazonIdentityManagementServiceClient(creds, region);
            ListGroupsResponse resp = new ListGroupsResponse();
            do
            {
                ListGroupsRequest req = new ListGroupsRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListGroups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Groups)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}