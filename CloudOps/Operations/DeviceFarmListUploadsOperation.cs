using Amazon;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DeviceFarmListUploadsOperation : Operation
    {
        public override string Name => "ListUploads";

        public override string Description => "Gets information about uploads, given an AWS Device Farm project ARN.";
 
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
                ListUploadsRequest req = new ListUploadsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListUploads(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Uploads)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}