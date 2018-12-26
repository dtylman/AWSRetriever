using Amazon;
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;
using Amazon.Runtime;

namespace CloudOps.MediaConnect
{
    public class ListFlowsOperation : Operation
    {
        public override string Name => "ListFlows";

        public override string Description => "Displays a list of flows that are associated with this account. This request returns a paginated result.";
 
        public override string RequestURI => "/v1/flows";

        public override string Method => "GET";

        public override string ServiceName => "MediaConnect";

        public override string ServiceID => "MediaConnect";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonMediaConnectClient client = new AmazonMediaConnectClient(creds, region);
            ListFlowsResponse resp = new ListFlowsResponse();
            do
            {
                ListFlowsRequest req = new ListFlowsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListFlows(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Flows)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}