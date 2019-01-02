using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.RDS
{
    public class ListTagsForResourceOperation : Operation
    {
        public override string Name => "ListTagsForResource";

        public override string Description => "";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
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