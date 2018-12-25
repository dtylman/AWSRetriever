using Amazon;
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IdentityManagementListGroupPoliciesOperation : Operation
    {
        public override string Name => "ListGroupPolicies";

        public override string Description => "Lists the names of the inline policies that are embedded in the specified IAM group. An IAM group can also have managed policies attached to it. To list the managed policies that are attached to a group, use ListAttachedGroupPolicies. For more information about policies, see Managed Policies and Inline Policies in the IAM User Guide. You can paginate the results using the MaxItems and Marker parameters. If there are no inline policies embedded with the specified group, the operation returns an empty list.";
 
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
                ListGroupPoliciesRequest req = new ListGroupPoliciesRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListGroupPolicies(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.PolicyNames)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}