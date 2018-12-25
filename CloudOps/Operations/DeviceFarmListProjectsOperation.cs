using Amazon;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DeviceFarmListProjectsOperation : Operation
    {
        public override string Name => "ListProjects";

        public override string Description => "Gets information about projects.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DeviceFarm";

        public override string ServiceID => "Device Farm";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDeviceFarmClient client = new AmazonDeviceFarmClient(creds, region);
            ListProjectsResultResponse resp = new ListProjectsResultResponse();
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