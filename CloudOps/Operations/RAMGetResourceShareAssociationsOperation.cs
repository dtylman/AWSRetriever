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
                GetResourceShareAssociationsRequest req = new GetResourceShareAssociationsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetResourceShareAssociations(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}