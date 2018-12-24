using Amazon;
using Amazon.AppStream;
using Amazon.AppStream.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AppStreamDescribeImagePermissionsOperation : Operation
    {
        public override string Name => "DescribeImagePermissions";

        public override string Description => "Retrieves a list that describes the permissions for shared AWS account IDs on a private image that you own. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AppStream";

        public override string ServiceID => "AppStream";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAppStreamClient client = new AmazonAppStreamClient(creds, region);
            DescribeImagePermissionsResult resp = new DescribeImagePermissionsResult();
            do
            {
                DescribeImagePermissionsRequest req = new DescribeImagePermissionsRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.DescribeImagePermissions(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}