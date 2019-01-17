using Amazon;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;
using Amazon.Runtime;

namespace CloudOps.DeviceFarm
{
    public class ListProjectsOperation : Operation
    {
        public override string Name => "ListProjects";

        public override string Description => "Gets information about projects.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DeviceFarm";

        public override string ServiceID => "Device Farm";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDeviceFarmConfig config = new AmazonDeviceFarmConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonDeviceFarmClient client = new AmazonDeviceFarmClient(creds, config);
            
            ListProjectsResponse resp = new ListProjectsResponse();
            do
            {
                ListProjectsRequest req = new ListProjectsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListProjects(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Projects)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}