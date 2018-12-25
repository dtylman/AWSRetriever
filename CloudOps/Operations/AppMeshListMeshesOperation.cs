using Amazon;
using Amazon.AppMesh;
using Amazon.AppMesh.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AppMeshListMeshesOperation : Operation
    {
        public override string Name => "ListMeshes";

        public override string Description => "Returns a list of existing service meshes.";
 
        public override string RequestURI => "/meshes";

        public override string Method => "GET";

        public override string ServiceName => "AppMesh";

        public override string ServiceID => "App Mesh";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAppMeshClient client = new AmazonAppMeshClient(creds, region);
            ListMeshesOutput resp = new ListMeshesOutput();
            do
            {
                ListMeshesInput req = new ListMeshesInput
                {
                    nextToken = resp.nextToken
                    ,
                    limit = maxItems
                                        
                };

                resp = client.ListMeshes(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.meshes)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}