using Amazon;
using Amazon.SMS;
using Amazon.SMS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SMSGetServersOperation : Operation
    {
        public override string Name => "GetServers";

        public override string Description => "Describes the servers in your server catalog. Before you can describe your servers, you must import them using ImportServerCatalog.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SMS";

        public override string ServiceID => "SMS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSMSClient client = new AmazonSMSClient(creds, region);
            GetServersResponse resp = new GetServersResponse();
            do
            {
                GetServersRequest req = new GetServersRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.GetServers(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.serverList)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}