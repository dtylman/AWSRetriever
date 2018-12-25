using Amazon;
using Amazon.CloudHSMV2;
using Amazon.CloudHSMV2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudHSMV2DescribeClustersOperation : Operation
    {
        public override string Name => "DescribeClusters";

        public override string Description => "Gets information about AWS CloudHSM clusters. This is a paginated operation, which means that each response might contain only a subset of all the clusters. When the response contains only a subset of clusters, it includes a NextToken value. Use this value in a subsequent DescribeClusters request to get more clusters. When you receive a response with no NextToken (or an empty or null value), that means there are no more clusters to get.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudHSMV2";

        public override string ServiceID => "CloudHSM V2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudHSMV2Client client = new AmazonCloudHSMV2Client(creds, region);
            DescribeClustersResponse resp = new DescribeClustersResponse();
            do
            {
                DescribeClustersRequest req = new DescribeClustersRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeClusters(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Clusters)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}