using Amazon;
using Amazon.SMS;
using Amazon.SMS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SMSGetReplicationRunsOperation : Operation
    {
        public override string Name => "GetReplicationRuns";

        public override string Description => "Describes the replication runs for the specified replication job.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SMS";

        public override string ServiceID => "SMS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSMSClient client = new AmazonSMSClient(creds, region);
            GetReplicationRunsResponse resp = new GetReplicationRunsResponse();
            do
            {
                GetReplicationRunsRequest req = new GetReplicationRunsRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.GetReplicationRuns(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.replicationRunList)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}