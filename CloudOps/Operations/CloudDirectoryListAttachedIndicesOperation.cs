using Amazon;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudDirectoryListAttachedIndicesOperation : Operation
    {
        public override string Name => "ListAttachedIndices";

        public override string Description => "Lists indices attached to the specified object.";
 
        public override string RequestURI => "/amazonclouddirectory/2017-01-11/object/indices";

        public override string Method => "POST";

        public override string ServiceName => "CloudDirectory";

        public override string ServiceID => "CloudDirectory";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudDirectoryClient client = new AmazonCloudDirectoryClient(creds, region);
            ListAttachedIndicesResponse resp = new ListAttachedIndicesResponse();
            do
            {
                ListAttachedIndicesRequest req = new ListAttachedIndicesRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListAttachedIndices(req);
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