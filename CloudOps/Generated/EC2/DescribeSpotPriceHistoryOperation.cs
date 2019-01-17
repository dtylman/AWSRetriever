using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.EC2
{
    public class DescribeSpotPriceHistoryOperation : Operation
    {
        public override string Name => "DescribeSpotPriceHistory";

        public override string Description => "Describes the Spot price history. For more information, see Spot Instance Pricing History in the Amazon EC2 User Guide for Linux Instances. When you specify a start and end time, this operation returns the prices of the instance types within the time range that you specified and the time when the price changed. The price is valid within the time period that you specified; the response merely indicates the last time that the price changed.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Config config = new AmazonEC2Config();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonEC2Client client = new AmazonEC2Client(creds, config);
            
            DescribeSpotPriceHistoryResponse resp = new DescribeSpotPriceHistoryResponse();
            do
            {
                DescribeSpotPriceHistoryRequest req = new DescribeSpotPriceHistoryRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeSpotPriceHistory(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.SpotPriceHistory)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}