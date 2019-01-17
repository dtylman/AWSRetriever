using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Amazon.Runtime;

namespace CloudOps.SimpleEmail
{
    public class ListIdentitiesOperation : Operation
    {
        public override string Name => "ListIdentities";

        public override string Description => "Returns a list containing all of the identities (email addresses and domains) for your AWS account in the current AWS Region, regardless of verification status. You can execute this operation no more than once per second.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SimpleEmail";

        public override string ServiceID => "SES";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
             AmazonSimpleEmailServiceConfig config = new AmazonSimpleEmailServiceConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonSimpleEmailServiceClient client = new AmazonSimpleEmailServiceClient(creds, config);
            
            ListIdentitiesResponse resp = new ListIdentitiesResponse();
            do
            {
                ListIdentitiesRequest req = new ListIdentitiesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListIdentities(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Identities)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}