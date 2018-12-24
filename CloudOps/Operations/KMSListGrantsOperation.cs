using Amazon;
using Amazon.KMS;
using Amazon.KMS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class KMSListGrantsOperation : Operation
    {
        public override string Name => "ListGrants";

        public override string Description => "Gets a list of all grants for the specified customer master key (CMK). To perform this operation on a CMK in a different AWS account, specify the key ARN in the value of the KeyId parameter.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "KMS";

        public override string ServiceID => "KMS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonKMSClient client = new AmazonKMSClient(creds, region);
            ListGrantsResponse resp = new ListGrantsResponse();
            do
            {
                ListGrantsRequest req = new ListGrantsRequest
                {
                    Marker = resp.NextMarker,
                    Limit = maxItems
                };
                resp = client.ListGrants(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Grants)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));
        }
    }
}