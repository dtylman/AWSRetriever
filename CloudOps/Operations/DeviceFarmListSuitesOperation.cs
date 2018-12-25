using Amazon;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DeviceFarmListSuitesOperation : Operation
    {
        public override string Name => "ListSuites";

        public override string Description => "Gets information about test suites for a given job.";
 
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
                ListSuitesRequest req = new ListSuitesRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListSuites(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Suites)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}