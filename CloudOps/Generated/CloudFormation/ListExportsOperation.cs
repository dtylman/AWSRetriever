using Amazon;
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;
using Amazon.Runtime;

namespace CloudOps.CloudFormation
{
    public class ListExportsOperation : Operation
    {
        public override string Name => "ListExports";

        public override string Description => "Lists all exported output values in the account and region in which you call this action. Use this action to see the exported output values that you can import into other stacks. To import values, use the  Fn::ImportValue  function.  For more information, see  AWS CloudFormation Export Stack Output Values.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "CloudFormation";

        public override string ServiceID => "CloudFormation";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudFormationClient client = new AmazonCloudFormationClient(creds, region);
            ListExportsResponse resp = new ListExportsResponse();
            do
            {
                ListExportsRequest req = new ListExportsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListExports(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Exports)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}