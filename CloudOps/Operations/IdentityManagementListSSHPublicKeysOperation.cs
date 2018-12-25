using Amazon;
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IdentityManagementListSSHPublicKeysOperation : Operation
    {
        public override string Name => "ListSSHPublicKeys";

        public override string Description => "Returns information about the SSH public keys associated with the specified IAM user. If there none exists, the operation returns an empty list. The SSH public keys returned by this operation are used only for authenticating the IAM user to an AWS CodeCommit repository. For more information about using SSH keys to authenticate to an AWS CodeCommit repository, see Set up AWS CodeCommit for SSH Connections in the AWS CodeCommit User Guide. Although each user is limited to a small number of keys, you can still paginate the results using the MaxItems and Marker parameters.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "IdentityManagement";

        public override string ServiceID => "IAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIdentityManagementClient client = new AmazonIdentityManagementClient(creds, region);
            ListSSHPublicKeysResponse resp = new ListSSHPublicKeysResponse();
            do
            {
                ListSSHPublicKeysRequest req = new ListSSHPublicKeysRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListSSHPublicKeys(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.SSHPublicKeys)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}