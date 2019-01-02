using Amazon;
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;
using Amazon.Runtime;

namespace CloudOps.StorageGateway
{
    public class DescribeStorediSCSIVolumesOperation : Operation
    {
        public override string Name => "DescribeStorediSCSIVolumes";

        public override string Description => "Returns the description of the gateway volumes specified in the request. The list of gateway volumes in the request must be from one gateway. In the response Amazon Storage Gateway returns volume information sorted by volume ARNs. This operation is only supported in stored volume gateway type.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "StorageGateway";

        public override string ServiceID => "Storage Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonStorageGatewayClient client = new AmazonStorageGatewayClient(creds, region);
            DescribeStorediSCSIVolumesResponse resp = new DescribeStorediSCSIVolumesResponse();
            DescribeStorediSCSIVolumesRequest req = new DescribeStorediSCSIVolumesRequest
            {                    
                                    
            };
            resp = client.DescribeStorediSCSIVolumes(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.StorediSCSIVolumes)
            {
                AddObject(obj);
            }
            
        }
    }
}