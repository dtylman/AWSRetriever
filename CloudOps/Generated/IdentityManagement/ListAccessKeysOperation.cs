using Amazon;
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;

namespace CloudOps.IdentityManagement
{
    public class ListAccessKeysOperation : Operation
    {
        public override string Name => "ListAccessKeys";

        public override string Description => "Returns information about the access key IDs associated with the specified IAM user. If there is none, the operation returns an empty list. Although each user is limited to a small number of keys, you can still paginate the results using the MaxItems and Marker parameters. If the UserName field is not specified, the user name is determined implicitly based on the AWS access key ID used to sign the request. This operation works for access keys under the AWS account. Consequently, you can use this operation to manage AWS account root user credentials even if the AWS account has no associated users.  To ensure the security of your AWS account, the secret access key is accessible only during key and user creation. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "IdentityManagement";

        public override string ServiceID => "IAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIdentityManagementServiceConfig config = new AmazonIdentityManagementServiceConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonIdentityManagementServiceClient client = new AmazonIdentityManagementServiceClient(creds, config);

            
            ListAccessKeysResponse resp = new ListAccessKeysResponse();
            do
            {
                ListAccessKeysRequest req = new ListAccessKeysRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListAccessKeys(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.AccessKeyMetadata)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}