using Amazon;
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;
using Amazon.Runtime;

namespace CloudOps.StorageGateway
{
    public class ListVolumeRecoveryPointsOperation : Operation
    {
        public override string Name => "ListVolumeRecoveryPoints";

        public override string Description => "Lists the recovery points for a specified gateway. This operation is only supported in the cached volume gateway type. Each cache volume has one recovery point. A volume recovery point is a point in time at which all data of the volume is consistent and from which you can create a snapshot or clone a new cached volume from a source volume. To create a snapshot from a volume recovery point use the CreateSnapshotFromVolumeRecoveryPoint operation.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "StorageGateway";

        public override string ServiceID => "Storage Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonStorageGatewayClient client = new AmazonStorageGatewayClient(creds, region);
            ListVolumeRecoveryPointsResponse resp = new ListVolumeRecoveryPointsResponse();
            ListVolumeRecoveryPointsRequest req = new ListVolumeRecoveryPointsRequest
            {                    
                                    
            };
            resp = client.ListVolumeRecoveryPoints(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.VolumeRecoveryPointInfos)
            {
                AddObject(obj);
            }
            
        }
    }
}