using Amazon;
using Amazon.Connect;
using Amazon.Connect.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ConnectGetMetricDataOperation : Operation
    {
        public override string Name => "GetMetricData";

        public override string Description => "The GetMetricData operation retrieves historical metrics data from your Amazon Connect instance. If you are using an IAM account, it must have permission to the connect:GetMetricData action.";
 
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
                GetMetricDataRequest req = new GetMetricDataRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetMetricData(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}