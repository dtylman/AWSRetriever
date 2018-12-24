using Amazon;
using Amazon.RAM;
using Amazon.RAM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RAMListPrincipalsOperation : Operation
    {
        public override string Name => "ListPrincipals";

        public override string Description => "Lists the principals with access to the specified resource.";
 
        public override string RequestURI => "/listprincipals";

        public override string Method => "POST";

        public override string ServiceName => "RAM";

        public override string ServiceID => "RAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRAMClient client = new AmazonRAMClient(creds, region);
            ListPrincipalsResponse resp = new ListPrincipalsResponse();
            do
            {
                ListPrincipalsRequest req = new ListPrincipalsRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.ListPrincipals(req);
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