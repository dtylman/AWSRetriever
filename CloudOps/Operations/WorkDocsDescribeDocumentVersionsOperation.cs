using Amazon;
using Amazon.WorkDocs;
using Amazon.WorkDocs.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class WorkDocsDescribeDocumentVersionsOperation : Operation
    {
        public override string Name => "DescribeDocumentVersions";

        public override string Description => "Retrieves the document versions for the specified document. By default, only active versions are returned.";
 
        public override string RequestURI => "/api/v1/documents/{DocumentId}/versions";

        public override string Method => "GET";

        public override string ServiceName => "WorkDocs";

        public override string ServiceID => "WorkDocs";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonWorkDocsClient client = new AmazonWorkDocsClient(creds, region);
            DescribeDocumentVersionsResponse resp = new DescribeDocumentVersionsResponse();
            do
            {
                DescribeDocumentVersionsRequest req = new DescribeDocumentVersionsRequest
                {
                    Marker = resp.Marker,
                    Limit = maxItems
                };
                resp = client.DescribeDocumentVersions(req);
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.DocumentVersions)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}