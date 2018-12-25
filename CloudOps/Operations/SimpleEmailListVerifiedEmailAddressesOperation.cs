using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SimpleEmailListVerifiedEmailAddressesOperation : Operation
    {
        public override string Name => "ListVerifiedEmailAddresses";

        public override string Description => "Deprecated. Use the ListIdentities operation to list the email addresses and domains associated with your account.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "SimpleEmail";

        public override string ServiceID => "SES";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSimpleEmailClient client = new AmazonSimpleEmailClient(creds, region);
            Response resp = new Response();
            Request req = new Request
            {                    
                                    
            };
            resp = client.ListVerifiedEmailAddresses(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.VerifiedEmailAddresses)
            {
                AddObject(obj);
            }
            
        }
    }
}