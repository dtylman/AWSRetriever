using Amazon;
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;
using Amazon.Runtime;

namespace CloudOps.DirectConnect
{
    public class DescribeLocationsOperation : Operation
    {
        public override string Name => "DescribeLocations";

        public override string Description => "Lists the AWS Direct Connect locations in the current AWS Region. These are the locations that can be selected when calling CreateConnection or CreateInterconnect.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DirectConnect";

        public override string ServiceID => "Direct Connect";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDirectConnectConfig config = new AmazonDirectConnectConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonDirectConnectClient client = new AmazonDirectConnectClient(creds, config);
            
            DescribeLocationsResponse resp = new DescribeLocationsResponse();
            DescribeLocationsRequest req = new DescribeLocationsRequest
            {                    
                                    
            };
            resp = client.DescribeLocations(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.Locations)
            {
                AddObject(obj);
            }
            
        }
    }
}