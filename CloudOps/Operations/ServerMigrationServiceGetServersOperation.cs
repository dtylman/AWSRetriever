using Amazon;
using Amazon.ServerMigrationService;
using Amazon.ServerMigrationService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServerMigrationServiceGetServersOperation : Operation
    {
        public override string Name => "GetServers";

        public override string Description => "Describes the servers in your server catalog. Before you can describe your servers, you must import them using ImportServerCatalog.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServerMigrationService";

        public override string ServiceID => "SMS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServerMigrationServiceClient client = new AmazonServerMigrationServiceClient(creds, region);
            GetServersResponse resp = new GetServersResponse();
            do
            {
                GetServersRequest req = new GetServersRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetServers(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ServerList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}