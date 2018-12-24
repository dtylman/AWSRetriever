using Amazon;
using Amazon.Route53;
using Amazon.Route53.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class Route53ListHealthChecksOperation : Operation
    {
        public override string Name => "ListHealthChecks";

        public override string Description => "Retrieve a list of the health checks that are associated with the current AWS account. ";
 
        public override string RequestURI => "/2013-04-01/healthcheck";

        public override string Method => "GET";

        public override string ServiceName => "Route53";

        public override string ServiceID => "Route 53";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRoute53Client client = new AmazonRoute53Client(creds, region);
            ListHealthChecksResponse resp = new ListHealthChecksResponse();
            do
            {
                ListHealthChecksRequest req = new ListHealthChecksRequest
                {
                    Marker = resp.NextMarker,
                    MaxItems = maxItems
                };
                resp = client.ListHealthChecks(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.HealthChecks)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));
        }
    }
}