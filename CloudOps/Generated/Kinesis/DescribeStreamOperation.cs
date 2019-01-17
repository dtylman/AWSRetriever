using Amazon;
using Amazon.Kinesis;
using Amazon.Kinesis.Model;
using Amazon.Runtime;

namespace CloudOps.Kinesis
{
    public class DescribeStreamOperation : Operation
    {
        public override string Name => "DescribeStream";

        public override string Description => "Describes the specified Kinesis data stream. The information returned includes the stream name, Amazon Resource Name (ARN), creation time, enhanced metric configuration, and shard map. The shard map is an array of shard objects. For each shard object, there is the hash key and sequence number ranges that the shard spans, and the IDs of any earlier shards that played in a role in creating the shard. Every record ingested in the stream is identified by a sequence number, which is assigned when the record is put into the stream. You can limit the number of shards returned by each call. For more information, see Retrieving Shards from a Stream in the Amazon Kinesis Data Streams Developer Guide. There are no guarantees about the chronological order shards returned. To process shards in chronological order, use the ID of the parent shard to track the lineage to the oldest shard. This operation has a limit of 10 transactions per second per account.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Kinesis";

        public override string ServiceID => "Kinesis";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonKinesisConfig config = new AmazonKinesisConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonKinesisClient client = new AmazonKinesisClient(creds, config);
            
            DescribeStreamResponse resp = new DescribeStreamResponse();
          
                DescribeStreamRequest req = new DescribeStreamRequest
                {
                    Limit = maxItems                                        
                };

                resp = client.DescribeStream(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            foreach (var obj in resp.StreamDescription.Shards)
                {
                    AddObject(obj);
                }
                
            }            
        }
}