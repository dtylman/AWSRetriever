using Amazon;
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DirectConnectDescribeLocationsOperation : Operation
    {
        public override string Name => "DescribeLocations";

        public override string Description => "Lists the AWS Direct Connect locations in the current AWS Region. These are the locations that can be selected when calling CreateConnection or CreateInterconnect.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "DirectConnect";

        public override string ServiceID => "Direct Connect";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDirectConnectClient client = new AmazonDirectConnectClient(creds, region);
            Response resp = new Response();
            Request req = new Request
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