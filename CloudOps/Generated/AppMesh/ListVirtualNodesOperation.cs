using Amazon;
using Amazon.AppMesh;
using Amazon.AppMesh.Model;
using Amazon.Runtime;

namespace CloudOps.AppMesh
{
    public class ListVirtualNodesOperation : Operation
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
            ListVirtualNodesResponse resp = new ListVirtualNodesResponse();
            do
            {
                ListVirtualNodesRequest req = new ListVirtualNodesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.ListVirtualNodes(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.VirtualNodes)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}