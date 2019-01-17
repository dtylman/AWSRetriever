using Amazon;
using Amazon.DataSync;
using Amazon.DataSync.Model;
using Amazon.Runtime;

namespace CloudOps.DataSync
{
    public class ListLocationsOperation : Operation
    {
        public override string Name => "ListLocations";

        public override string Description => "Returns a lists of source and destination locations. If you have more locations than are returned in a response (that is, the response returns only a truncated list of your agents), the response contains a token that you can specify in your next request to fetch the next page of locations.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DataSync";

        public override string ServiceID => "DataSync";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDataSyncConfig config = new AmazonDataSyncConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonDataSyncClient client = new AmazonDataSyncClient(creds, config);
            
            ListLocationsResponse resp = new ListLocationsResponse();
            do
            {
                ListLocationsRequest req = new ListLocationsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListLocations(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Locations)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}