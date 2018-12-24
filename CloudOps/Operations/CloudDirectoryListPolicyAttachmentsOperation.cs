using Amazon;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudDirectoryListPolicyAttachmentsOperation : Operation
    {
        public override string Name => "ListPolicyAttachments";

        public override string Description => "Returns all of the ObjectIdentifiers to which a given policy is attached.";
 
        public override string RequestURI => "/amazonclouddirectory/2017-01-11/policy/attachment";

        public override string Method => "POST";

        public override string ServiceName => "CloudDirectory";

        public override string ServiceID => "CloudDirectory";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudDirectoryClient client = new AmazonCloudDirectoryClient(creds, region);
            ListPolicyAttachmentsResponse resp = new ListPolicyAttachmentsResponse();
            do
            {
                ListPolicyAttachmentsRequest req = new ListPolicyAttachmentsRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListPolicyAttachments(req);
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}