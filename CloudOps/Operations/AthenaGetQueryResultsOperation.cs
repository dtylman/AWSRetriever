using Amazon;
using Amazon.Athena;
using Amazon.Athena.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AthenaGetQueryResultsOperation : Operation
    {
        public override string Name => "GetQueryResults";

        public override string Description => "Returns the results of a single query execution specified by QueryExecutionId. This request does not execute the query but returns results. Use StartQueryExecution to run a query.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Athena";

        public override string ServiceID => "Athena";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAthenaClient client = new AmazonAthenaClient(creds, region);
            GetQueryResultsOutput resp = new GetQueryResultsOutput();
            do
            {
                GetQueryResultsInput req = new GetQueryResultsInput
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.GetQueryResults(req);
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