using Amazon;
using Amazon.Glacier;
using Amazon.Glacier.Model;
using Amazon.Runtime;

namespace CloudOps.Glacier
{
    public class ListMultipartUploadsOperation : Operation
    {
        public override string Name => "ListMultipartUploads";

        public override string Description => "This operation lists in-progress multipart uploads for the specified vault. An in-progress multipart upload is a multipart upload that has been initiated by an InitiateMultipartUpload request, but has not yet been completed or aborted. The list returned in the List Multipart Upload response has no guaranteed order.  The List Multipart Uploads operation supports pagination. By default, this operation returns up to 50 multipart uploads in the response. You should always check the response for a marker at which to continue the list; if there are no more items the marker is null. To return a list of multipart uploads that begins at a specific upload, set the marker request parameter to the value you obtained from a previous List Multipart Upload request. You can also limit the number of uploads returned in the response by specifying the limit parameter in the request. Note the difference between this operation and listing parts (ListParts). The List Multipart Uploads operation lists all multipart uploads for a vault and does not require a multipart upload ID. The List Parts operation requires a multipart upload ID since parts are associated with a single upload. An AWS account has full permission to perform all operations (actions). However, AWS Identity and Access Management (IAM) users don&#39;t have any permissions by default. You must grant them explicit permission to perform specific actions. For more information, see Access Control Using AWS Identity and Access Management (IAM). For conceptual information and the underlying REST API, see Working with Archives in Amazon Glacier and List Multipart Uploads  in the Amazon Glacier Developer Guide.";
 
        public override string RequestURI => "/{accountId}/vaults/{vaultName}/multipart-uploads";

        public override string Method => "GET";

        public override string ServiceName => "Glacier";

        public override string ServiceID => "Glacier";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGlacierConfig config = new AmazonGlacierConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonGlacierClient client = new AmazonGlacierClient(creds, config);
            
            ListMultipartUploadsResponse resp = new ListMultipartUploadsResponse();
            do
            {
                ListMultipartUploadsRequest req = new ListMultipartUploadsRequest
                {
                    Limit = maxItems
                };

                resp = client.ListMultipartUploads(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.UploadsList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}