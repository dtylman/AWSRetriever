using Amazon;
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class GuardDutyListFiltersOperation : Operation
    {
        public override string Name => "ListFilters";

        public override string Description => "Returns a paginated list of the current filters.";
 
        public override string RequestURI => "/detector/{detectorId}/filter";

        public override string Method => "GET";

        public override string ServiceName => "GuardDuty";

        public override string ServiceID => "GuardDuty";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGuardDutyClient client = new AmazonGuardDutyClient(creds, region);
            ListFiltersResponse resp = new ListFiltersResponse();
            do
            {
                ListFiltersRequest req = new ListFiltersRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListFilters(req);
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.FilterNames)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}