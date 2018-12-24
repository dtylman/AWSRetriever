using Amazon;
using Amazon.RAM;
using Amazon.RAM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RAMGetResourceShareAssociationsOperation : Operation
    {
        public override string Name => "GetResourceShareAssociations";

        public override string Description => "Gets the associations for the specified resource share.";
 
        public override string RequestURI => "/getresourceshareassociations";

        public override string Method => "POST";

        public override string ServiceName => "RAM";

        public override string ServiceID => "RAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRAMClient client = new AmazonRAMClient(creds, region);
            GetResourceShareAssociationsResponse resp = new GetResourceShareAssociationsResponse();
            do
            {
                GetResourceShareAssociationsRequest req = new GetResourceShareAssociationsRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.GetResourceShareAssociations(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}