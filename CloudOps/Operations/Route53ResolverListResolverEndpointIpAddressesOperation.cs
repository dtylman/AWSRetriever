using Amazon;
using Amazon.Route53Resolver;
using Amazon.Route53Resolver.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class Route53ResolverListResolverEndpointIpAddressesOperation : Operation
    {
        public override string Name => "ListResolverEndpointIpAddresses";

        public override string Description => "Gets the IP addresses for a specified resolver endpoint.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "Route53Resolver";

        public override string ServiceID => "Route53Resolver";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRoute53ResolverClient client = new AmazonRoute53ResolverClient(creds, region);
            Response resp = new Response();
            do
            {
                ListResolverEndpointIpAddressesRequest req = new ListResolverEndpointIpAddressesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListResolverEndpointIpAddresses(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}