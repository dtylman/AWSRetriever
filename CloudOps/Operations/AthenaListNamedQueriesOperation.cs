using Amazon;
using Amazon.Athena;
using Amazon.Athena.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AthenaListNamedQueriesOperation : Operation
    {
        public override string Name => "ListNamedQueries";

        public override string Description => "Provides a list of all available query IDs. For code samples using the AWS SDK for Java, see Examples and Code Samples in the Amazon Athena User Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Athena";

        public override string ServiceID => "Athena";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAthenaClient client = new AmazonAthenaClient(creds, region);
            ListNamedQueriesOutput resp = new ListNamedQueriesOutput();
            do
            {
                ListNamedQueriesInput req = new ListNamedQueriesInput
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListNamedQueries(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}