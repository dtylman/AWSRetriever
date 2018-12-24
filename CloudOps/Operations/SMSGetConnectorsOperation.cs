using Amazon;
using Amazon.SMS;
using Amazon.SMS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SMSGetConnectorsOperation : Operation
    {
        public override string Name => "GetConnectors";

        public override string Description => "Describes the connectors registered with the AWS SMS.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SMS";

        public override string ServiceID => "SMS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSMSClient client = new AmazonSMSClient(creds, region);
            GetConnectorsResponse resp = new GetConnectorsResponse();
            do
            {
                GetConnectorsRequest req = new GetConnectorsRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.GetConnectors(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.connectorList)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}