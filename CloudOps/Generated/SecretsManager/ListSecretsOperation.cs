using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Amazon.Runtime;

namespace CloudOps.SecretsManager
{
    public class ListSecretsOperation : Operation
    {
        public override string Name => "ListSecrets";

        public override string Description => "Lists all of the secrets that are stored by Secrets Manager in the AWS account. To list the versions currently stored for a specific secret, use ListSecretVersionIds. The encrypted fields SecretString and SecretBinary are not included in the output. To get that information, call the GetSecretValue operation.  Always check the NextToken response parameter when calling any of the List* operations. These operations can occasionally return an empty or shorter than expected list of results even when there are more results available. When this happens, the NextToken response parameter contains a value to pass to the next call to the same API to request the next part of the list.   Minimum permissions  To run this command, you must have the following permissions:   secretsmanager:ListSecrets    Related operations    To list the versions attached to a secret, use ListSecretVersionIds.  ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SecretsManager";

        public override string ServiceID => "Secrets Manager";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSecretsManagerConfig config = new AmazonSecretsManagerConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonSecretsManagerClient client = new AmazonSecretsManagerClient(creds, config);
            
            ListSecretsResponse resp = new ListSecretsResponse();
            do
            {
                ListSecretsRequest req = new ListSecretsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListSecrets(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.SecretList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}