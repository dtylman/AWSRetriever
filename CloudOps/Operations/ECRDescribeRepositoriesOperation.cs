using Amazon;
using Amazon.ECR;
using Amazon.ECR.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ECRDescribeRepositoriesOperation : Operation
    {
        public override string Name => "DescribeRepositories";

        public override string Description => "Describes image repositories in a registry.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ECR";

        public override string ServiceID => "ECR";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonECRClient client = new AmazonECRClient(creds, region);
            DescribeRepositoriesResponse resp = new DescribeRepositoriesResponse();
            do
            {
                DescribeRepositoriesRequest req = new DescribeRepositoriesRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.DescribeRepositories(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.repositories)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}