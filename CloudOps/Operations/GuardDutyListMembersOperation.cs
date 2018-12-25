using Amazon;
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class GuardDutyListMembersOperation : Operation
    {
        public override string Name => "ListMembers";

        public override string Description => "Lists details about all member accounts for the current GuardDuty master account.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "GuardDuty";

        public override string ServiceID => "GuardDuty";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGuardDutyClient client = new AmazonGuardDutyClient(creds, region);
            Response resp = new Response();
            do
            {
                ListMembersRequest req = new ListMembersRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListMembers(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Members)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}