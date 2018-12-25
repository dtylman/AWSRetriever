using Amazon;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudDirectoryListObjectPoliciesOperation : Operation
    {
        public override string Name => "ListObjectPolicies";

        public override string Description => "Returns policies attached to an object in pagination fashion.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "CloudDirectory";

        public override string ServiceID => "CloudDirectory";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudDirectoryClient client = new AmazonCloudDirectoryClient(creds, region);
            Response resp = new Response();
            do
            {
                ListObjectPoliciesRequest req = new ListObjectPoliciesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListObjectPolicies(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}