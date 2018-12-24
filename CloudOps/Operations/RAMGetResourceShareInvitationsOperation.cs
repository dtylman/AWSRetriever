using Amazon;
using Amazon.RAM;
using Amazon.RAM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RAMGetResourceShareInvitationsOperation : Operation
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
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.GetResourceShareInvitations(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}