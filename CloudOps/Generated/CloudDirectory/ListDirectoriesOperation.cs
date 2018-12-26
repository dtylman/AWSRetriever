using Amazon;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;
using Amazon.Runtime;

namespace CloudOps.CloudDirectory
{
    public class ListDirectoriesOperation : Operation
    {
        public override string Name => "ListDirectories";

        public override string Description => "Lists directories created within an account.";
 
        public override string RequestURI => "/amazonclouddirectory/2017-01-11/directory/list";

        public override string Method => "POST";

        public override string ServiceName => "CloudDirectory";

        public override string ServiceID => "CloudDirectory";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudDirectoryClient client = new AmazonCloudDirectoryClient(creds, region);
            ListDirectoriesResponse resp = new ListDirectoriesResponse();
            do
            {
                ListDirectoriesRequest req = new ListDirectoriesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListDirectories(req);
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