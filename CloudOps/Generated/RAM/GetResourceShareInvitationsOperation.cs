using Amazon;
using Amazon.RAM;
using Amazon.RAM.Model;
using Amazon.Runtime;

namespace CloudOps.RAM
{
    public class GetResourceShareInvitationsOperation : Operation
    {
        public override string Name => "GetResourceShareInvitations";

        public override string Description => "Gets the specified invitations for resource sharing.";
 
        public override string RequestURI => "/getresourceshareinvitations";

        public override string Method => "POST";

        public override string ServiceName => "RAM";

        public override string ServiceID => "RAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRAMClient client = new AmazonRAMClient(creds, region);
            GetResourceShareInvitationsResponse resp = new GetResourceShareInvitationsResponse();
            do
            {
                GetResourceShareInvitationsRequest req = new GetResourceShareInvitationsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetResourceShareInvitations(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ResourceShareInvitations)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}