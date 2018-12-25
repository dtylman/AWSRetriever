using Amazon;
using Amazon.Athena;
using Amazon.Athena.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AthenaListQueryExecutionsOperation : Operation
    {
        public override string Name => "ListQueryExecutions";

        public override string Description => "Provides a list of all available query execution IDs. For code samples using the AWS SDK for Java, see Examples and Code Samples in the Amazon Athena User Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Athena";

        public override string ServiceID => "Athena";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAthenaClient client = new AmazonAthenaClient(creds, region);
            ListQueryExecutionsOutput resp = new ListQueryExecutionsOutput();
            do
            {
                ListQueryExecutionsInput req = new ListQueryExecutionsInput
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListQueryExecutions(req);
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