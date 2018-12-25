using Amazon;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SimpleSystemsManagementGetParametersByPathOperation : Operation
    {
        public override string Name => "GetParametersByPath";

        public override string Description => "Retrieve parameters in a specific hierarchy. For more information, see Working with Systems Manager Parameters in the AWS Systems Manager User Guide.  Request results are returned on a best-effort basis. If you specify MaxResults in the request, the response includes information up to the limit specified. The number of items returned, however, can be between zero and the value of MaxResults. If the service reaches an internal limit while processing the results, it stops the operation and returns the matching values up to that point and a NextToken. You can specify the NextToken in a subsequent call to get the next set of results.  This API action doesn&#39;t support filtering by tags.  ";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "SimpleSystemsManagement";

        public override string ServiceID => "SSM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSimpleSystemsManagementClient client = new AmazonSimpleSystemsManagementClient(creds, region);
            Response resp = new Response();
            do
            {
                GetParametersByPathRequest req = new GetParametersByPathRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetParametersByPath(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}