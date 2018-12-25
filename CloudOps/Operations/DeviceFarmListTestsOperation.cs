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
                ListTestsRequest req = new ListTestsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListTests(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Tests)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}