using Amazon;
using Amazon.RAM;
using Amazon.RAM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RAMListResourcesOperation : Operation
    {
        public override string Name => "ListResources";

        public override string Description => "Lists the resources that the specified principal can access.";
 
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
                ListResourcesRequest req = new ListResourcesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListResources(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}