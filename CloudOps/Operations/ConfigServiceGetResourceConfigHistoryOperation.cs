using Amazon;
using Amazon.ConfigService;
using Amazon.ConfigService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ConfigServiceGetResourceConfigHistoryOperation : Operation
    {
        public override string Name => "GetResourceConfigHistory";

        public override string Description => "Returns a list of configuration items for the specified resource. The list contains details about each state of the resource during the specified time interval. If you specified a retention period to retain your ConfigurationItems between a minimum of 30 days and a maximum of 7 years (2557 days), AWS Config returns the ConfigurationItems for the specified retention period.  The response is paginated. By default, AWS Config returns a limit of 10 configuration items per page. You can customize this number with the limit parameter. The response includes a nextToken string. To get the next page of results, run the request again and specify the string for the nextToken parameter.  Each call to the API is limited to span a duration of seven days. It is likely that the number of records returned is smaller than the specified limit. In such cases, you can make another call, using the nextToken. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ConfigService";

        public override string ServiceID => "Config Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonConfigServiceClient client = new AmazonConfigServiceClient(creds, region);
            GetResourceConfigHistoryResponse resp = new GetResourceConfigHistoryResponse();
            do
            {
                GetResourceConfigHistoryRequest req = new GetResourceConfigHistoryRequest
                {
                    nextToken = resp.nextToken,
                    limit = maxItems
                };
                resp = client.GetResourceConfigHistory(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.configurationItems)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}