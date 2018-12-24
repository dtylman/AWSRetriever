using Amazon;
using Amazon.AppMesh;
using Amazon.AppMesh.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AppMeshListVirtualRoutersOperation : Operation
    {
        public override string Name => "ListVirtualRouters";

        public override string Description => "Returns a list of existing virtual routers in a service mesh.";
 
        public override string RequestURI => "/meshes/{meshName}/virtualRouters";

        public override string Method => "GET";

        public override string ServiceName => "AppMesh";

        public override string ServiceID => "App Mesh";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAppMeshClient client = new AmazonAppMeshClient(creds, region);
            ListVirtualRoutersOutput resp = new ListVirtualRoutersOutput();
            do
            {
                ListVirtualRoutersInput req = new ListVirtualRoutersInput
                {
                    nextToken = resp.nextToken,
                    limit = maxItems
                };
                resp = client.ListVirtualRouters(req);
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.virtualRouters)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}