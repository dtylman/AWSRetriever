using Amazon;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DeviceFarmListDevicesOperation : Operation
    {
        public override string Name => "ListDevices";

        public override string Description => "Gets information about unique device types.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DeviceFarm";

        public override string ServiceID => "Device Farm";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDeviceFarmClient client = new AmazonDeviceFarmClient(creds, region);
            ListDevicesResult resp = new ListDevicesResult();
            do
            {
                ListDevicesRequest req = new ListDevicesRequest
                {
                    nextToken = resp.nextToken
                                        
                };

                resp = client.ListDevices(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.devices)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}