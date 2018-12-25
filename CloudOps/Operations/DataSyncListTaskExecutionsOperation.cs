using Amazon;
using Amazon.DataSync;
using Amazon.DataSync.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DataSyncListTaskExecutionsOperation : Operation
    {
        public override string Name => "ListTaskExecutions";

        public override string Description => "Returns a list of executed tasks.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DataSync";

        public override string ServiceID => "DataSync";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDataSyncClient client = new AmazonDataSyncClient(creds, region);
            ListTaskExecutionsResponse resp = new ListTaskExecutionsResponse();
            do
            {
                ListTaskExecutionsRequest req = new ListTaskExecutionsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListTaskExecutions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}