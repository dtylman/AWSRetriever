using Amazon;
using Amazon.PinpointEmail;
using Amazon.PinpointEmail.Model;
using Amazon.Runtime;

namespace CloudOps.PinpointEmail
{
    public class ListConfigurationSetsOperation : Operation
    {
        public override string Name => "ListConfigurationSets";

        public override string Description => "List all of the configuration sets associated with your Amazon Pinpoint account in the current region. In Amazon Pinpoint, configuration sets are groups of rules that you can apply to the emails you send. You apply a configuration set to an email by including a reference to the configuration set in the headers of the email. When you apply a configuration set to an email, all of the rules in that configuration set are applied to the email.";
 
        public override string RequestURI => "/v1/email/configuration-sets";

        public override string Method => "GET";

        public override string ServiceName => "PinpointEmail";

        public override string ServiceID => "Pinpoint Email";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonPinpointEmailConfig config = new AmazonPinpointEmailConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonPinpointEmailClient client = new AmazonPinpointEmailClient(creds, config);
            
            ListConfigurationSetsResponse resp = new ListConfigurationSetsResponse();
            do
            {
                ListConfigurationSetsRequest req = new ListConfigurationSetsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.ListConfigurationSets(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ConfigurationSets)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}