using Amazon;
using Amazon.AppMesh;
using Amazon.AppMesh.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AppMeshListVirtualNodesOperation : Operation
    {
        public override string Name => "ListVirtualNodes";

        public override string Description => "Returns a list of existing virtual nodes.";
 
        public override string RequestURI => "/meshes/{meshName}/virtualNodes";

        public override string Method => "GET";

        public override string ServiceName => "AppMesh";

        public override string ServiceID => "App Mesh";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAppMeshClient client = new AmazonAppMeshClient(creds, region);
            ListVirtualNodesOutput resp = new ListVirtualNodesOutput();
            do
            {
                ListVirtualNodesInput req = new ListVirtualNodesInput
                {
                    nextToken = resp.nextToken,
                    limit = maxItems
                };
                resp = client.ListVirtualNodes(req);
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.virtualNodes)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}