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
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "AppMesh";

        public override string ServiceID => "App Mesh";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAppMeshClient client = new AmazonAppMeshClient(creds, region);
            Response resp = new Response();
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