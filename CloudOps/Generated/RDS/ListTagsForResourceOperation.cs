using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.RDS
{
    public class ListTagsForResourceOperation : Operation
    {
        public override string Name => "ListTagsForResource";

        public override string Description => "Lists all tags on an Amazon RDS resource. For an overview on tagging an Amazon RDS resource, see Tagging Amazon RDS Resources in the Amazon RDS User Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSConfig config = new AmazonRDSConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonRDSClient client = new AmazonRDSClient(creds, config);
            
            ListTagsForResourceResponse resp = new ListTagsForResourceResponse();
            ListTagsForResourceRequest req = new ListTagsForResourceRequest
            {                    
                                    
            };
            resp = client.ListTagsForResource(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.TagList)
            {
                AddObject(obj);
            }
            
        }
    }
}