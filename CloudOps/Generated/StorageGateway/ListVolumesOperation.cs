using Amazon;
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;
using Amazon.Runtime;

namespace CloudOps.StorageGateway
{
    public class ListVolumesOperation : Operation
    {
        public override string Name => "ListVolumes";

        public override string Description => "Lists the iSCSI stored volumes of a gateway. Results are sorted by volume ARN. The response includes only the volume ARNs. If you want additional volume information, use the DescribeStorediSCSIVolumes or the DescribeCachediSCSIVolumes API. The operation supports pagination. By default, the operation returns a maximum of up to 100 volumes. You can optionally specify the Limit field in the body to limit the number of volumes in the response. If the number of volumes returned in the response is truncated, the response includes a Marker field. You can use this Marker value in your subsequent request to retrieve the next set of volumes. This operation is only supported in the cached volume and stored volume gateway types.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "StorageGateway";

        public override string ServiceID => "Storage Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonStorageGatewayConfig config = new AmazonStorageGatewayConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonStorageGatewayClient client = new AmazonStorageGatewayClient(creds, config);
            
            ListVolumesResponse resp = new ListVolumesResponse();
            do
            {
                ListVolumesRequest req = new ListVolumesRequest
                {
                    Marker = resp.Marker
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.ListVolumes(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.VolumeInfos)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}