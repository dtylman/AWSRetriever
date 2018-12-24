using Amazon;
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class WorkSpacesDescribeWorkspaceBundlesOperation : Operation
    {
        public override string Name => "DescribeWorkspaceBundles";

        public override string Description => "Retrieves a list that describes the available WorkSpace bundles. You can filter the results using either bundle ID or owner, but not both.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "WorkSpaces";

        public override string ServiceID => "WorkSpaces";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonWorkSpacesClient client = new AmazonWorkSpacesClient(creds, region);
            DescribeWorkspaceBundlesResult resp = new DescribeWorkspaceBundlesResult();
            do
            {
                DescribeWorkspaceBundlesRequest req = new DescribeWorkspaceBundlesRequest
                {
                    NextToken = resp.NextToken,
                    &lt;nil&gt; = maxItems
                };
                resp = client.DescribeWorkspaceBundles(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Bundles)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}