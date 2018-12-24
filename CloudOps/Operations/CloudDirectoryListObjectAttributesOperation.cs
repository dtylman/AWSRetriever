using Amazon;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudDirectoryListObjectAttributesOperation : Operation
    {
        public override string Name => "ListObjectAttributes";

        public override string Description => "Lists all attributes that are associated with an object. ";
 
        public override string RequestURI => "/amazonclouddirectory/2017-01-11/object/attributes";

        public override string Method => "POST";

        public override string ServiceName => "CloudDirectory";

        public override string ServiceID => "CloudDirectory";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudDirectoryClient client = new AmazonCloudDirectoryClient(creds, region);
            ListObjectAttributesResponse resp = new ListObjectAttributesResponse();
            do
            {
                ListObjectAttributesRequest req = new ListObjectAttributesRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListObjectAttributes(req);
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