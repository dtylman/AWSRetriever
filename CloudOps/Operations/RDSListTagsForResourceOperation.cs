using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RDSListTagsForResourceOperation : Operation
    {
        public override string Name => "ListTagsForResource";

        public override string Description => "Lists all tags on an Amazon RDS resource. For an overview on tagging an Amazon RDS resource, see Tagging Amazon RDS Resources in the Amazon RDS User Guide.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            Response resp = new Response();
            ListTagsForResourceMessageRequest req = new ListTagsForResourceMessageRequest
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