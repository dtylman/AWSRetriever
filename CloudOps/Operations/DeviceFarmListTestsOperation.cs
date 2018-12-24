using Amazon;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DeviceFarmListTestsOperation : Operation
    {
        public override string Name => "ListTests";

        public override string Description => "Gets information about tests in a given test suite.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DeviceFarm";

        public override string ServiceID => "Device Farm";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDeviceFarmClient client = new AmazonDeviceFarmClient(creds, region);
            ListTestsResult resp = new ListTestsResult();
            do
            {
                ListTestsRequest req = new ListTestsRequest
                {
                    nextToken = resp.nextToken,
                    &lt;nil&gt; = maxItems
                };
                resp = client.ListTests(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.tests)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}