using Amazon;
using Amazon.SSM;
using Amazon.SSM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SSMListCommandInvocationsOperation : Operation
    {
        public override string Name => "ListCommandInvocations";

        public override string Description => "An invocation is copy of a command sent to a specific instance. A command can apply to one or more instances. A command invocation applies to one instance. For example, if a user executes SendCommand against three instances, then a command invocation is created for each requested instance ID. ListCommandInvocations provide status about command execution.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SSM";

        public override string ServiceID => "SSM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSSMClient client = new AmazonSSMClient(creds, region);
            ListCommandInvocationsResult resp = new ListCommandInvocationsResult();
            do
            {
                ListCommandInvocationsRequest req = new ListCommandInvocationsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListCommandInvocations(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.CommandInvocations)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}