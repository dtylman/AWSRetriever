using Amazon;
using Amazon.Snowball;
using Amazon.Snowball.Model;
using Amazon.Runtime;

namespace CloudOps.Snowball
{
    public class DescribeAddressesOperation : Operation
    {
        public override string Name => "DescribeAddresses";

        public override string Description => "Returns a specified number of ADDRESS objects. Calling this API in one of the US regions will return addresses from the list of all addresses associated with this account in all US regions.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Snowball";

        public override string ServiceID => "Snowball";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSnowballClient client = new AmazonSnowballClient(creds, region);
            DescribeAddressesResponse resp = new DescribeAddressesResponse();
            do
            {
                DescribeAddressesRequest req = new DescribeAddressesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeAddresses(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Addresses)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}