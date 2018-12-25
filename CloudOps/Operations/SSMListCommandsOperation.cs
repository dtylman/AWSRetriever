using Amazon;
using Amazon.SSM;
using Amazon.SSM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SSMListCommandsOperation : Operation
    {
        public override string Name => "ListCommands";

        public override string Description => "Lists the commands requested by users of the AWS account.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SSM";

        public override string ServiceID => "SSM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSSMClient client = new AmazonSSMClient(creds, region);
            ListCommandsResult resp = new ListCommandsResult();
            do
            {
                ListCommandsRequest req = new ListCommandsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListCommands(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Commands)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}