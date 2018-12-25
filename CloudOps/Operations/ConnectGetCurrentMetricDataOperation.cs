using Amazon;
using Amazon.Connect;
using Amazon.Connect.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ConnectGetCurrentMetricDataOperation : Operation
    {
        public override string Name => "GetCurrentMetricData";

        public override string Description => "The GetCurrentMetricData operation retrieves current metric data from your Amazon Connect instance. If you are using an IAM account, it must have permission to the connect:GetCurrentMetricData action.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "Connect";

        public override string ServiceID => "Connect";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonConnectClient client = new AmazonConnectClient(creds, region);
            Response resp = new Response();
            do
            {
                GetCurrentMetricDataRequest req = new GetCurrentMetricDataRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetCurrentMetricData(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}