using Amazon;
using Amazon.PinpointEmail;
using Amazon.PinpointEmail.Model;
using Amazon.Runtime;

namespace CloudOps.PinpointEmail
{
    public class ListDeliverabilityTestReportsOperation : Operation
    {
        public override string Name => "ListDeliverabilityTestReports";

        public override string Description => "Show a list of the predictive inbox placement tests that you&#39;ve performed, regardless of their statuses. For predictive inbox placement tests that are complete, you can use the GetDeliverabilityTestReport operation to view the results.";
 
        public override string RequestURI => "/v1/email/deliverability-dashboard/test-reports";

        public override string Method => "GET";

        public override string ServiceName => "PinpointEmail";

        public override string ServiceID => "Pinpoint Email";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonPinpointEmailClient client = new AmazonPinpointEmailClient(creds, region);
            ListDeliverabilityTestReportsResponse resp = new ListDeliverabilityTestReportsResponse();
            do
            {
                ListDeliverabilityTestReportsRequest req = new ListDeliverabilityTestReportsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.ListDeliverabilityTestReports(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DeliverabilityTestReports)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}