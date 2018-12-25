using Amazon;
using Amazon.ServerMigrationService;
using Amazon.ServerMigrationService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServerMigrationServiceGetConnectorsOperation : Operation
    {
        public override string Name => "GetConnectors";

        public override string Description => "Describes the connectors registered with the AWS SMS.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServerMigrationService";

        public override string ServiceID => "SMS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServerMigrationServiceClient client = new AmazonServerMigrationServiceClient(creds, region);
            GetConnectorsResponse resp = new GetConnectorsResponse();
            do
            {
                GetConnectorsRequest req = new GetConnectorsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetConnectors(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ConnectorList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}