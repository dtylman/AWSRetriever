using Amazon;
using Amazon.AppMesh;
using Amazon.AppMesh.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AppMeshListRoutesOperation : Operation
    {
        public override string Name => "ListRoutes";

        public override string Description => "Returns a list of existing routes in a service mesh.";
 
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
                ListRoutesRequest req = new ListRoutesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.ListRoutes(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Routes)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}