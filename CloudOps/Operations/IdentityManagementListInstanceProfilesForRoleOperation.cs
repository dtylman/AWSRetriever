using Amazon;
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IdentityManagementListInstanceProfilesForRoleOperation : Operation
    {
        public override string Name => "ListInstanceProfilesForRole";

        public override string Description => "Lists the instance profiles that have the specified associated IAM role. If there are none, the operation returns an empty list. For more information about instance profiles, go to About Instance Profiles. You can paginate the results using the MaxItems and Marker parameters.";
 
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
                ListInstanceProfilesForRoleRequest req = new ListInstanceProfilesForRoleRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListInstanceProfilesForRole(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.InstanceProfiles)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}