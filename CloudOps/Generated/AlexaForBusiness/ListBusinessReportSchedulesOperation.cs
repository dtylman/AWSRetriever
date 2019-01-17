using Amazon;
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;
using Amazon.Runtime;

namespace CloudOps.AlexaForBusiness
{
    public class ListBusinessReportSchedulesOperation : Operation
    {
        public override string Name => "ListBusinessReportSchedules";

        public override string Description => "Lists the details of the schedules that a user configured.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AlexaForBusiness";

        public override string ServiceID => "Alexa For Business";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAlexaForBusinessConfig config = new AmazonAlexaForBusinessConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonAlexaForBusinessClient client = new AmazonAlexaForBusinessClient(creds, config);
            
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
                
                foreach (var obj in resp.BusinessReportSchedules)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}