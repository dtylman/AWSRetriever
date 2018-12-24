using Amazon;
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class GuardDutyListFindingsOperation : Operation
    {
        public override string Name => "ListFindings";

        public override string Description => "Lists Amazon GuardDuty findings for the specified detector ID.";
 
        public override string RequestURI => "/detector/{detectorId}/findings";

        public override string Method => "POST";

        public override string ServiceName => "GuardDuty";

        public override string ServiceID => "GuardDuty";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGuardDutyClient client = new AmazonGuardDutyClient(creds, region);
            ListFindingsResponse resp = new ListFindingsResponse();
            do
            {
                ListFindingsRequest req = new ListFindingsRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListFindings(req);
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.FindingIds)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}