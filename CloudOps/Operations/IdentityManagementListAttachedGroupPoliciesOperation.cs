using Amazon;
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IdentityManagementListAttachedGroupPoliciesOperation : Operation
    {
        public override string Name => "ListAttachedGroupPolicies";

        public override string Description => "Lists all managed policies that are attached to the specified IAM group. An IAM group can also have inline policies embedded with it. To list the inline policies for a group, use the ListGroupPolicies API. For information about policies, see Managed Policies and Inline Policies in the IAM User Guide. You can paginate the results using the MaxItems and Marker parameters. You can use the PathPrefix parameter to limit the list of policies to only those matching the specified path prefix. If there are no policies attached to the specified group (or none that match the specified path prefix), the operation returns an empty list.";
 
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
                ListAttachedGroupPoliciesRequest req = new ListAttachedGroupPoliciesRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListAttachedGroupPolicies(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.AttachedPolicies)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}