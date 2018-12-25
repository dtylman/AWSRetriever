using Amazon;
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class StorageGatewayDescribeCachediSCSIVolumesOperation : Operation
    {
        public override string Name => "DescribeCachediSCSIVolumes";

        public override string Description => "Returns a description of the gateway volumes specified in the request. This operation is only supported in the cached volume gateway types. The list of gateway volumes in the request must be from one gateway. In the response Amazon Storage Gateway returns volume information sorted by volume Amazon Resource Name (ARN).";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "StorageGateway";

        public override string ServiceID => "Storage Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonStorageGatewayClient client = new AmazonStorageGatewayClient(creds, region);
            Response resp = new Response();
            DescribeCachediSCSIVolumesRequest req = new DescribeCachediSCSIVolumesRequest
            {                    
                                    
            };
            resp = client.DescribeCachediSCSIVolumes(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.CachediSCSIVolumes)
            {
                AddObject(obj);
            }
            
        }
    }
}