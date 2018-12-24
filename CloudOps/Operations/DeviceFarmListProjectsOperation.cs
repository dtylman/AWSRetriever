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
            ListProjectsResult resp = new ListProjectsResult();
            do
            {
                ListProjectsRequest req = new ListProjectsRequest
                {
                    nextToken = resp.nextToken,
                    &lt;nil&gt; = maxItems
                };
                resp = client.ListProjects(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.projects)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}