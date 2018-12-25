using Amazon;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DeviceFarmListDevicePoolsOperation : Operation
    {
        public override string Name => "ListDevicePools";

        public override string Description => "Gets information about device pools.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "DeviceFarm";

        public override string ServiceID => "Device Farm";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDeviceFarmClient client = new AmazonDeviceFarmClient(creds, region);
            Response resp = new Response();
            do
            {
                ListDevicePoolsRequest req = new ListDevicePoolsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListDevicePools(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DevicePools)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}