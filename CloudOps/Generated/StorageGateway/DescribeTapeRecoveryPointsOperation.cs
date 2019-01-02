using Amazon;
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;
using Amazon.Runtime;

namespace CloudOps.StorageGateway
{
    public class DescribeTapeRecoveryPointsOperation : Operation
    {
        public override string Name => "DescribeTapeRecoveryPoints";

        public override string Description => "Returns a list of virtual tape recovery points that are available for the specified tape gateway. A recovery point is a point-in-time view of a virtual tape at which all the data on the virtual tape is consistent. If your gateway crashes, virtual tapes that have recovery points can be recovered to a new gateway. This operation is only supported in the tape gateway type.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "StorageGateway";

        public override string ServiceID => "Storage Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonStorageGatewayClient client = new AmazonStorageGatewayClient(creds, region);
            DescribeTapeRecoveryPointsResponse resp = new DescribeTapeRecoveryPointsResponse();
            do
            {
                DescribeTapeRecoveryPointsRequest req = new DescribeTapeRecoveryPointsRequest
                {
                    Marker = resp.Marker
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.DescribeTapeRecoveryPoints(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.TapeRecoveryPointInfos)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}