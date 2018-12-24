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
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DeviceFarm";

        public override string ServiceID => "Device Farm";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDeviceFarmClient client = new AmazonDeviceFarmClient(creds, region);
            ListSuitesResult resp = new ListSuitesResult();
            do
            {
                ListSuitesRequest req = new ListSuitesRequest
                {
                    nextToken = resp.nextToken,
                    &lt;nil&gt; = maxItems
                };
                resp = client.ListSuites(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.suites)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}