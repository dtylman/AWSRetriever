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
 
        public override string RequestURI => "/getresourcepolicies";

        public override string Method => "POST";

        public override string ServiceName => "RAM";

        public override string ServiceID => "RAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRAMClient client = new AmazonRAMClient(creds, region);
            GetResourcePoliciesResponse resp = new GetResourcePoliciesResponse();
            do
            {
                GetResourcePoliciesRequest req = new GetResourcePoliciesRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.GetResourcePolicies(req);
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