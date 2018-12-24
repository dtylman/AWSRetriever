using Amazon;
using Amazon.WorkDocs;
using Amazon.WorkDocs.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class WorkDocsDescribeFolderContentsOperation : Operation
    {
        public override string Name => "DescribeFolderContents";

        public override string Description => "Describes the contents of the specified folder, including its documents and subfolders. By default, Amazon WorkDocs returns the first 100 active document and folder metadata items. If there are more results, the response includes a marker that you can use to request the next set of results. You can also request initialized documents.";
 
        public override string RequestURI => "/api/v1/folders/{FolderId}/contents";

        public override string Method => "GET";

        public override string ServiceName => "WorkDocs";

        public override string ServiceID => "WorkDocs";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonWorkDocsClient client = new AmazonWorkDocsClient(creds, region);
            DescribeFolderContentsResponse resp = new DescribeFolderContentsResponse();
            do
            {
                DescribeFolderContentsRequest req = new DescribeFolderContentsRequest
                {
                    Marker = resp.Marker,
                    Limit = maxItems
                };
                resp = client.DescribeFolderContents(req);
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.[Folders Documents])
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}