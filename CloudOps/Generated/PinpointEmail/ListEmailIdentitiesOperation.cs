using Amazon;
using Amazon.PinpointEmail;
using Amazon.PinpointEmail.Model;
using Amazon.Runtime;

namespace CloudOps.PinpointEmail
{
    public class ListEmailIdentitiesOperation : Operation
    {
        public override string Name => "ListEmailIdentities";

        public override string Description => "Returns a list of all of the email identities that are associated with your Amazon Pinpoint account. An identity can be either an email address or a domain. This operation returns identities that are verified as well as those that aren&#39;t.";
 
        public override string RequestURI => "/v1/email/identities";

        public override string Method => "GET";

        public override string ServiceName => "PinpointEmail";

        public override string ServiceID => "Pinpoint Email";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonPinpointEmailClient client = new AmazonPinpointEmailClient(creds, region);
            ListEmailIdentitiesResponse resp = new ListEmailIdentitiesResponse();
            do
            {
                ListEmailIdentitiesRequest req = new ListEmailIdentitiesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    PageSize = maxItems
                                        
                };

                resp = client.ListEmailIdentities(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.EmailIdentities)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}