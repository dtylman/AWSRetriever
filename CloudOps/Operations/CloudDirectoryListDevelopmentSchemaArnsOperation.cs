using Amazon;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudDirectoryListDevelopmentSchemaArnsOperation : Operation
    {
        public override string Name => "ListDevelopmentSchemaArns";

        public override string Description => "Retrieves each Amazon Resource Name (ARN) of schemas in the development state.";
 
        public override string RequestURI => "/amazonclouddirectory/2017-01-11/schema/development";

        public override string Method => "POST";

        public override string ServiceName => "CloudDirectory";

        public override string ServiceID => "CloudDirectory";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudDirectoryClient client = new AmazonCloudDirectoryClient(creds, region);
            ListDevelopmentSchemaArnsResponse resp = new ListDevelopmentSchemaArnsResponse();
            do
            {
                ListDevelopmentSchemaArnsRequest req = new ListDevelopmentSchemaArnsRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListDevelopmentSchemaArns(req);
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}