using Amazon;
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AlexaForBusinessListBusinessReportSchedulesOperation : Operation
    {
        public override string Name => "ListBusinessReportSchedules";

        public override string Description => "Lists the details of the schedules that a user configured.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AlexaForBusiness";

        public override string ServiceID => "Alexa For Business";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAlexaForBusinessClient client = new AmazonAlexaForBusinessClient(creds, region);
            ListBusinessReportSchedulesResponse resp = new ListBusinessReportSchedulesResponse();
            do
            {
                ListBusinessReportSchedulesRequest req = new ListBusinessReportSchedulesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListBusinessReportSchedules(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}