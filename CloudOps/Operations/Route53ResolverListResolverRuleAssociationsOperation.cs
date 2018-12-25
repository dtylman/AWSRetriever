using Amazon;
using Amazon.Route53Resolver;
using Amazon.Route53Resolver.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class Route53ResolverListResolverRuleAssociationsOperation : Operation
    {
        public override string Name => "ListResolverRuleAssociations";

        public override string Description => "Lists the associations that were created between resolver rules and VPCs using the current AWS account.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Route53Resolver";

        public override string ServiceID => "Route53Resolver";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRoute53ResolverClient client = new AmazonRoute53ResolverClient(creds, region);
            ListResolverRuleAssociationsResponse resp = new ListResolverRuleAssociationsResponse();
            do
            {
                ListResolverRuleAssociationsRequest req = new ListResolverRuleAssociationsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListResolverRuleAssociations(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ResolverRuleAssociations)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}