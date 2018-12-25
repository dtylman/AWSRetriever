using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SecretsManagerListSecretVersionIdsOperation : Operation
    {
        public override string Name => "ListSecretVersionIds";

        public override string Description => "Lists all of the versions attached to the specified secret. The output does not include the SecretString or SecretBinary fields. By default, the list includes only versions that have at least one staging label in VersionStage attached.  Always check the NextToken response parameter when calling any of the List* operations. These operations can occasionally return an empty or shorter than expected list of results even when there are more results available. When this happens, the NextToken response parameter contains a value to pass to the next call to the same API to request the next part of the list.   Minimum permissions  To run this command, you must have the following permissions:   secretsmanager:ListSecretVersionIds    Related operations    To list the secrets in an account, use ListSecrets.  ";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "SecretsManager";

        public override string ServiceID => "Secrets Manager";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSecretsManagerClient client = new AmazonSecretsManagerClient(creds, region);
            Response resp = new Response();
            do
            {
                ListSecretVersionIdsRequest req = new ListSecretVersionIdsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListSecretVersionIds(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}