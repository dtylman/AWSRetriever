using Amazon;
using Amazon.AppMesh;
using Amazon.AppMesh.Model;
using Amazon.Runtime;

namespace CloudOps.AppMesh
{
    public class ListVirtualRoutersOperation : Operation
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
            ListVirtualRoutersResponse resp = new ListVirtualRoutersResponse();
            do
            {
                ListVirtualRoutersRequest req = new ListVirtualRoutersRequest
                {
                    NextToken = resp.NextToken
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.ListVirtualRouters(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.VirtualRouters)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}