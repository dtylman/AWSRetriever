using Amazon;
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class GuardDutyListThreatIntelSetsOperation : Operation
    {
        public override string Name => "ListThreatIntelSets";

        public override string Description => "Lists the ThreatIntelSets of the GuardDuty service specified by the detector ID.";
 
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
                ListThreatIntelSetsRequest req = new ListThreatIntelSetsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListThreatIntelSets(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ThreatIntelSetIds)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}