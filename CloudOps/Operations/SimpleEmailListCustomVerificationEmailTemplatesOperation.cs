using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SimpleEmailListCustomVerificationEmailTemplatesOperation : Operation
    {
        public override string Name => "ListCustomVerificationEmailTemplates";

        public override string Description => "Lists the existing custom verification email templates for your account in the current AWS Region. For more information about custom verification email templates, see Using Custom Verification Email Templates in the Amazon SES Developer Guide. You can execute this operation no more than once per second.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SimpleEmail";

        public override string ServiceID => "SES";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSimpleEmailClient client = new AmazonSimpleEmailClient(creds, region);
            ListCustomVerificationEmailTemplatesResponse resp = new ListCustomVerificationEmailTemplatesResponse();
            do
            {
                ListCustomVerificationEmailTemplatesRequest req = new ListCustomVerificationEmailTemplatesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListCustomVerificationEmailTemplates(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.CustomVerificationEmailTemplates)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}