using Amazon;
using Amazon.KMS;
using Amazon.KMS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class KMSListAliasesOperation : Operation
    {
        public override string Name => "ListAliases";

        public override string Description => "Gets a list of all aliases in the caller&#39;s AWS account and region. You cannot list aliases in other accounts. For more information about aliases, see CreateAlias. By default, the ListAliases command returns all aliases in the account and region. To get only the aliases that point to a particular customer master key (CMK), use the KeyId parameter. The ListAliases response might include several aliases have no TargetKeyId field. These are predefined aliases that AWS has created but has not yet associated with a CMK. Aliases that AWS creates in your account, including predefined aliases, do not count against your AWS KMS aliases limit.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "KMS";

        public override string ServiceID => "KMS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonKMSClient client = new AmazonKMSClient(creds, region);
            ListAliasesResponse resp = new ListAliasesResponse();
            do
            {
                ListAliasesRequest req = new ListAliasesRequest
                {
                    Marker = resp.NextMarker,
                    Limit = maxItems
                };
                resp = client.ListAliases(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Aliases)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));
        }
    }
}