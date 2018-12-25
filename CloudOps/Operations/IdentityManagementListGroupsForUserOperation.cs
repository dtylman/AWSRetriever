using Amazon;
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IdentityManagementListGroupsForUserOperation : Operation
    {
        public override string Name => "ListGroupsForUser";

        public override string Description => "Lists the IAM groups that the specified IAM user belongs to. You can paginate the results using the MaxItems and Marker parameters.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "IdentityManagement";

        public override string ServiceID => "IAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIdentityManagementClient client = new AmazonIdentityManagementClient(creds, region);
            Response resp = new Response();
            do
            {
                ListGroupsForUserRequest req = new ListGroupsForUserRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListGroupsForUser(req);
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