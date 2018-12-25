using Amazon;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DeviceFarmListArtifactsOperation : Operation
    {
        public override string Name => "ListArtifacts";

        public override string Description => "Gets information about artifacts.";
 
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
                ListArtifactsRequest req = new ListArtifactsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListArtifacts(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Artifacts)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}