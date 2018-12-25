using Amazon;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SimpleSystemsManagementGetParameterHistoryOperation : Operation
    {
        public override string Name => "GetParameterHistory";

        public override string Description => "Query a list of all parameters used by the AWS account.";
 
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
                GetParameterHistoryRequest req = new GetParameterHistoryRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetParameterHistory(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}