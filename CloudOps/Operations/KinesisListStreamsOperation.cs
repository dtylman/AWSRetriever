using Amazon;
using Amazon.Kinesis;
using Amazon.Kinesis.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class KinesisListStreamsOperation : Operation
    {
        public override string Name => "ListStreams";

        public override string Description => "Lists your Kinesis data streams. The number of streams may be too large to return from a single call to ListStreams. You can limit the number of returned streams using the Limit parameter. If you do not specify a value for the Limit parameter, Kinesis Data Streams uses the default limit, which is currently 10. You can detect if there are more streams available to list by using the HasMoreStreams flag from the returned output. If there are more streams available, you can request more streams by using the name of the last stream returned by the ListStreams request in the ExclusiveStartStreamName parameter in a subsequent request to ListStreams. The group of stream names returned by the subsequent request is then added to the list. You can continue this process until all the stream names have been collected in the list.   ListStreams has a limit of five transactions per second per account.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Kinesis";

        public override string ServiceID => "Kinesis";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonKinesisClient client = new AmazonKinesisClient(creds, region);
            ListStreamsOutput resp = new ListStreamsOutput();
            do
            {
                ListStreamsInput req = new ListStreamsInput
                {
                    ExclusiveStartStreamName = resp.StreamNames[-1]
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.ListStreams(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.StreamNames)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.StreamNames[-1]));
        }
    }
}