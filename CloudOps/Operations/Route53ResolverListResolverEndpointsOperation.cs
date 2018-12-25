using Amazon;
using Amazon.Route53Resolver;
using Amazon.Route53Resolver.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class Route53ResolverListResolverEndpointsOperation : Operation
    {
        public override string Name => "ListResolverEndpoints";

        public override string Description => "Lists all the resolver endpoints that were created using the current AWS account.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Route53Resolver";

        public override string ServiceID => "Route53Resolver";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRoute53ResolverClient client = new AmazonRoute53ResolverClient(creds, region);
            ListResolverEndpointsResponse resp = new ListResolverEndpointsResponse();
            do
            {
                ListResolverEndpointsRequest req = new ListResolverEndpointsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListResolverEndpoints(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ResolverEndpoints)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}