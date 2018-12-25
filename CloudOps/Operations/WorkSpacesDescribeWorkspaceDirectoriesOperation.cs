using Amazon;
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class WorkSpacesDescribeWorkspaceDirectoriesOperation : Operation
    {
        public override string Name => "DescribeWorkspaceDirectories";

        public override string Description => "Describes the available AWS Directory Service directories that are registered with Amazon WorkSpaces.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "WorkSpaces";

        public override string ServiceID => "WorkSpaces";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonWorkSpacesClient client = new AmazonWorkSpacesClient(creds, region);
            DescribeWorkspaceDirectoriesResult resp = new DescribeWorkspaceDirectoriesResult();
            do
            {
                DescribeWorkspaceDirectoriesRequest req = new DescribeWorkspaceDirectoriesRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.DescribeWorkspaceDirectories(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Directories)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}