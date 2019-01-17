using Amazon;
using Amazon.Route53;
using Amazon.Route53.Model;
using Amazon.Runtime;

namespace CloudOps.Route53
{
    public class ListHostedZonesOperation : Operation
    {
        public override string Name => "ListHostedZones";

        public override string Description => "Retrieves a list of the public and private hosted zones that are associated with the current AWS account. The response includes a HostedZones child element for each hosted zone. Amazon Route 53 returns a maximum of 100 items in each response. If you have a lot of hosted zones, you can use the maxitems parameter to list them in groups of up to 100.";
 
        public override string RequestURI => "/2013-04-01/hostedzone";

        public override string Method => "GET";

        public override string ServiceName => "Route53";

        public override string ServiceID => "Route 53";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRoute53Config config = new AmazonRoute53Config();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonRoute53Client client = new AmazonRoute53Client(creds, config);
            
            ListHostedZonesResponse resp = new ListHostedZonesResponse();
            do
            {
                ListHostedZonesRequest req = new ListHostedZonesRequest
                {
                    Marker = resp.NextMarker
                    ,
                    MaxItems = maxItems.ToString()
                                        
                };

                resp = client.ListHostedZones(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.HostedZones)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextMarker));
        }
    }
}