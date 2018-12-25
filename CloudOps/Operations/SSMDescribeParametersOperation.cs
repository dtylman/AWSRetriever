using Amazon;
using Amazon.SSM;
using Amazon.SSM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SSMDescribeParametersOperation : Operation
    {
        public override string Name => "DescribeParameters";

        public override string Description => "Get information about a parameter. Request results are returned on a best-effort basis. If you specify MaxResults in the request, the response includes information up to the limit specified. The number of items returned, however, can be between zero and the value of MaxResults. If the service reaches an internal limit while processing the results, it stops the operation and returns the matching values up to that point and a NextToken. You can specify the NextToken in a subsequent call to get the next set of results.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SSM";

        public override string ServiceID => "SSM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSSMClient client = new AmazonSSMClient(creds, region);
            DescribeParametersResult resp = new DescribeParametersResult();
            do
            {
                DescribeParametersRequest req = new DescribeParametersRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeParameters(req);
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