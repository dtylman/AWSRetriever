using Amazon;
using Amazon.Organizations;
using Amazon.Organizations.Model;
using Amazon.Runtime;

namespace CloudOps.Organizations
{
    public class ListHandshakesForOrganizationOperation : Operation
    {
        public override string Name => "ListHandshakesForOrganization";

        public override string Description => "Lists the handshakes that are associated with the organization that the requesting user is part of. The ListHandshakesForOrganization operation returns a list of handshake structures. Each structure contains details and status about a handshake. Handshakes that are ACCEPTED, DECLINED, or CANCELED appear in the results of this API for only 30 days after changing to that state. After that they are deleted and no longer accessible.  Always check the NextToken response parameter for a null value when calling a List* operation. These operations can occasionally return an empty set of results even when there are more results available. The NextToken response parameter value is null only when there are no more results to display.  This operation can be called only from the organization&#39;s master account.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Organizations";

        public override string ServiceID => "Organizations";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonOrganizationsConfig config = new AmazonOrganizationsConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonOrganizationsClient client = new AmazonOrganizationsClient(creds, config);
            
            ListHandshakesForOrganizationResponse resp = new ListHandshakesForOrganizationResponse();
            do
            {
                ListHandshakesForOrganizationRequest req = new ListHandshakesForOrganizationRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListHandshakesForOrganization(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Handshakes)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}