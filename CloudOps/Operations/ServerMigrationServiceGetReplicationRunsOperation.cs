using Amazon;
using Amazon.ServerMigrationService;
using Amazon.ServerMigrationService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServerMigrationServiceGetReplicationRunsOperation : Operation
    {
        public override string Name => "GetReplicationRuns";

        public override string Description => "Describes the replication runs for the specified replication job.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "ServerMigrationService";

        public override string ServiceID => "SMS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServerMigrationServiceClient client = new AmazonServerMigrationServiceClient(creds, region);
            Response resp = new Response();
            do
            {
                GetReplicationRunsRequest req = new GetReplicationRunsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetReplicationRuns(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ReplicationRunList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}