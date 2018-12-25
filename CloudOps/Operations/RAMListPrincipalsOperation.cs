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
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "RAM";

        public override string ServiceID => "RAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRAMClient client = new AmazonRAMClient(creds, region);
            Response resp = new Response();
            do
            {
                ListPrincipalsRequest req = new ListPrincipalsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListPrincipals(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}