using Amazon;
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;
using Amazon.Runtime;

namespace CloudOps.StorageGateway
{
    public class DescribeVTLDevicesOperation : Operation
    {
        public override string Name => "DescribeVTLDevices";

        public override string Description => "Returns a description of virtual tape library (VTL) devices for the specified tape gateway. In the response, AWS Storage Gateway returns VTL device information. This operation is only supported in the tape gateway type.";
 
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
            
            DescribeVTLDevicesResponse resp = new DescribeVTLDevicesResponse();
            do
            {
                DescribeVTLDevicesRequest req = new DescribeVTLDevicesRequest
                {
                    Marker = resp.Marker
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.DescribeVTLDevices(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.VTLDevices)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}