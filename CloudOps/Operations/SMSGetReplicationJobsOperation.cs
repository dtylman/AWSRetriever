using Amazon;
using Amazon.SMS;
using Amazon.SMS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SMSGetReplicationJobsOperation : Operation
    {
        public override string Name => "GetReplicationJobs";

        public override string Description => "Describes the specified replication job or all of your replication jobs.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SMS";

        public override string ServiceID => "SMS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSMSClient client = new AmazonSMSClient(creds, region);
            GetReplicationJobsResponse resp = new GetReplicationJobsResponse();
            do
            {
                GetReplicationJobsRequest req = new GetReplicationJobsRequest
                {
                    nextToken = resp.nextToken
                    ,
                    maxResults = maxItems
                                        
                };

                resp = client.GetReplicationJobs(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.replicationJobList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}