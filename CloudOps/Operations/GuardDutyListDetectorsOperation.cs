using Amazon;
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class GuardDutyListDetectorsOperation : Operation
    {
        public override string Name => "ListDetectors";

        public override string Description => "Lists detectorIds of all the existing Amazon GuardDuty detector resources.";
 
        public override string RequestURI => "/detector";

        public override string Method => "GET";

        public override string ServiceName => "GuardDuty";

        public override string ServiceID => "GuardDuty";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGuardDutyClient client = new AmazonGuardDutyClient(creds, region);
            ListDetectorsResponse resp = new ListDetectorsResponse();
            do
            {
                ListDetectorsRequest req = new ListDetectorsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListDetectors(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DetectorIds)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}