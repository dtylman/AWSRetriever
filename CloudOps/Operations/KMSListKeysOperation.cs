using Amazon;
using Amazon.KMS;
using Amazon.KMS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class KMSListKeysOperation : Operation
    {
        public override string Name => "ListKeys";

        public override string Description => "Gets a list of all customer master keys (CMKs) in the caller&#39;s AWS account and region.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "KMS";

        public override string ServiceID => "KMS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonKMSClient client = new AmazonKMSClient(creds, region);
            ListKeysResponse resp = new ListKeysResponse();
            do
            {
                ListKeysRequest req = new ListKeysRequest
                {
                    Marker = resp.NextMarker
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.ListKeys(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Keys)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));
        }
    }
}