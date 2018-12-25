using Amazon;
using Amazon.Kinesis;
using Amazon.Kinesis.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class KinesisListStreamConsumersOperation : Operation
    {
        public override string Name => "ListStreamConsumers";

        public override string Description => "Lists the consumers registered to receive data from a stream using enhanced fan-out, and provides information about each consumer. This operation has a limit of 10 transactions per second per account.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "Kinesis";

        public override string ServiceID => "Kinesis";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonKinesisClient client = new AmazonKinesisClient(creds, region);
            Response resp = new Response();
            do
            {
                ListStreamConsumersRequest req = new ListStreamConsumersRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListStreamConsumers(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}