using Amazon;
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IdentityManagementListEntitiesForPolicyOperation : Operation
    {
        public override string Name => "ListEntitiesForPolicy";

        public override string Description => "Lists all IAM users, groups, and roles that the specified managed policy is attached to. You can use the optional EntityFilter parameter to limit the results to a particular type of entity (users, groups, or roles). For example, to list only the roles that are attached to the specified policy, set EntityFilter to Role. You can paginate the results using the MaxItems and Marker parameters.";
 
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
                ListEntitiesForPolicyRequest req = new ListEntitiesForPolicyRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListEntitiesForPolicy(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}