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
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            TagListMessage resp = new TagListMessage();
            do
            {
                ListTagsForResourceMessage req = new ListTagsForResourceMessage
                {
                    &lt;nil&gt; = resp.&lt;nil&gt;,
                    &lt;nil&gt; = maxItems
                };
                resp = client.ListTagsForResource(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.TagList)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.&lt;nil&gt;));
        }
    }
}