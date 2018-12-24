using Amazon;
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class GuardDutyListIPSetsOperation : Operation
    {
        public override string Name => "ListIPSets";

        public override string Description => "Lists the IPSets of the GuardDuty service specified by the detector ID.";
 
        public override string RequestURI => "/detector/{detectorId}/ipset";

        public override string Method => "GET";

        public override string ServiceName => "GuardDuty";

        public override string ServiceID => "GuardDuty";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGuardDutyClient client = new AmazonGuardDutyClient(creds, region);
            ListIPSetsResponse resp = new ListIPSetsResponse();
            do
            {
                ListIPSetsRequest req = new ListIPSetsRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListIPSets(req);
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.IpSetIds)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}