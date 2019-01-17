using Amazon;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Amazon.Runtime;

namespace CloudOps.SimpleSystemsManagement
{
    public class ListCommandInvocationsOperation : Operation
    {
        public override string Name => "ListCommandInvocations";

        public override string Description => "An invocation is copy of a command sent to a specific instance. A command can apply to one or more instances. A command invocation applies to one instance. For example, if a user executes SendCommand against three instances, then a command invocation is created for each requested instance ID. ListCommandInvocations provide status about command execution.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SimpleSystemsManagement";

        public override string ServiceID => "SSM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSimpleSystemsManagementConfig config = new AmazonSimpleSystemsManagementConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonSimpleSystemsManagementClient client = new AmazonSimpleSystemsManagementClient(creds, config);
            
            ListCommandInvocationsResponse resp = new ListCommandInvocationsResponse();
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