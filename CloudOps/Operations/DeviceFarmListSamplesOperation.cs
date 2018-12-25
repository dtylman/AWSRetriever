using Amazon;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DeviceFarmListSamplesOperation : Operation
    {
        public override string Name => "ListSamples";

        public override string Description => "Gets information about samples, given an AWS Device Farm job ARN.";
 
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
                ListSamplesRequest req = new ListSamplesRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListSamples(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Samples)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}