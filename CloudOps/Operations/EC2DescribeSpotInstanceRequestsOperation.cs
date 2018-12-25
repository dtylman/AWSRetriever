using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class EC2DescribeSpotInstanceRequestsOperation : Operation
    {
        public override string Name => "DescribeSpotInstanceRequests";

        public override string Description => "Describes the specified Spot Instance requests. You can use DescribeSpotInstanceRequests to find a running Spot Instance by examining the response. If the status of the Spot Instance is fulfilled, the instance ID appears in the response and contains the identifier of the instance. Alternatively, you can use DescribeInstances with a filter to look for instances where the instance lifecycle is spot. Spot Instance requests are deleted four hours after they are canceled and their instances are terminated.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribeSpotInstanceRequestsResult resp = new DescribeSpotInstanceRequestsResult();
            DescribeSpotInstanceRequestsRequest req = new DescribeSpotInstanceRequestsRequest
            {                    
                                    
            };
            resp = client.DescribeSpotInstanceRequests(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.SpotInstanceRequests)
            {
                AddObject(obj);
            }
            
        }
    }
}