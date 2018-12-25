using Amazon;
using Amazon.DataSync;
using Amazon.DataSync.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DataSyncListTasksOperation : Operation
    {
        public override string Name => "ListTasks";

        public override string Description => "Returns a list of all the tasks.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DataSync";

        public override string ServiceID => "DataSync";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDataSyncClient client = new AmazonDataSyncClient(creds, region);
            ListTasksResponse resp = new ListTasksResponse();
            do
            {
                ListTasksRequest req = new ListTasksRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListTasks(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Tasks)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}