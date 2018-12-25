using Amazon;
using Amazon.Glacier;
using Amazon.Glacier.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class GlacierListVaultsOperation : Operation
    {
        public override string Name => "ListVaults";

        public override string Description => "This operation lists all vaults owned by the calling user&#39;s account. The list returned in the response is ASCII-sorted by vault name. By default, this operation returns up to 10 items. If there are more vaults to list, the response marker field contains the vault Amazon Resource Name (ARN) at which to continue the list with a new List Vaults request; otherwise, the marker field is null. To return a list of vaults that begins at a specific vault, set the marker request parameter to the vault ARN you obtained from a previous List Vaults request. You can also limit the number of vaults returned in the response by specifying the limit parameter in the request.  An AWS account has full permission to perform all operations (actions). However, AWS Identity and Access Management (IAM) users don&#39;t have any permissions by default. You must grant them explicit permission to perform specific actions. For more information, see Access Control Using AWS Identity and Access Management (IAM). For conceptual information and underlying REST API, see Retrieving Vault Metadata in Amazon Glacier and List Vaults  in the Amazon Glacier Developer Guide. ";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "Glacier";

        public override string ServiceID => "Glacier";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGlacierClient client = new AmazonGlacierClient(creds, region);
            Response resp = new Response();
            do
            {
                ListVaultsRequest req = new ListVaultsRequest
                {
                    Marker = resp.Marker
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.ListVaults(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.VaultList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}