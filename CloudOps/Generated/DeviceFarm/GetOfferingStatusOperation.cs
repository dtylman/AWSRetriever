using Amazon;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;
using Amazon.Runtime;

namespace CloudOps.DeviceFarm
{
    public class GetOfferingStatusOperation : Operation
    {
        public override string Name => "GetOfferingStatus";

        public override string Description => "Gets the current status and future status of all offerings purchased by an AWS account. The response indicates how many offerings are currently available and the offerings that will be available in the next period. The API returns a NotEligible error if the user is not permitted to invoke the operation. Please contact aws-devicefarm-support@amazon.com if you believe that you should be able to invoke this operation.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DeviceFarm";

        public override string ServiceID => "Device Farm";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDeviceFarmConfig config = new AmazonDeviceFarmConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonDeviceFarmClient client = new AmazonDeviceFarmClient(creds, config);
            
            GetOfferingStatusResponse resp = new GetOfferingStatusResponse();
            do
            {
                GetOfferingStatusRequest req = new GetOfferingStatusRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.GetOfferingStatus(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Current)
                {
                    AddObject(obj);
                }
                
                foreach (var obj in resp.NextPeriod)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}