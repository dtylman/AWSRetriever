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
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "Athena";

        public override string ServiceID => "Athena";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAthenaClient client = new AmazonAthenaClient(creds, region);
            Response resp = new Response();
            do
            {
                GetQueryResultsRequest req = new GetQueryResultsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetQueryResults(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}