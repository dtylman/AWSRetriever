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
 
        public override string RequestURI => "/metrics/current/{InstanceId}";

        public override string Method => "POST";

        public override string ServiceName => "Connect";

        public override string ServiceID => "Connect";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonConnectClient client = new AmazonConnectClient(creds, region);
            GetCurrentMetricDataResponse resp = new GetCurrentMetricDataResponse();
            do
            {
                GetCurrentMetricDataRequest req = new GetCurrentMetricDataRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.GetCurrentMetricData(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}