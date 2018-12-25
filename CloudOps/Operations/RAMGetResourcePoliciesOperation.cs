using Amazon;
using Amazon.RAM;
using Amazon.RAM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RAMGetResourcePoliciesOperation : Operation
    {
        public override string Name => "GetResourcePolicies";

        public override string Description => "Gets the policies for the specifies resources.";
 
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
                GetResourcePoliciesRequest req = new GetResourcePoliciesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetResourcePolicies(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}