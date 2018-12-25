using Amazon;
using Amazon.RAM;
using Amazon.RAM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RAMGetResourceSharesOperation : Operation
    {
        public override string Name => "GetResourceShares";

        public override string Description => "Gets the specified resource shares or all of your resource shares.";
 
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
                GetResourceSharesRequest req = new GetResourceSharesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetResourceShares(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}