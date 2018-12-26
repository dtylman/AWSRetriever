using Amazon;
using Amazon.Route53Resolver;
using Amazon.Route53Resolver.Model;
using Amazon.Runtime;

namespace CloudOps.Route53Resolver
{
    public class ListResolverRulesOperation : Operation
    {
        public override string Name => "ListResolverRules";

        public override string Description => "Lists the resolver rules that were created using the current AWS account.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Route53Resolver";

        public override string ServiceID => "Route53Resolver";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRoute53ResolverClient client = new AmazonRoute53ResolverClient(creds, region);
            ListResolverRulesResponse resp = new ListResolverRulesResponse();
            do
            {
                ListResolverRulesRequest req = new ListResolverRulesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListResolverRules(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ResolverRules)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}