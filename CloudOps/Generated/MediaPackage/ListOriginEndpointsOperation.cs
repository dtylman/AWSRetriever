using Amazon;
using Amazon.MediaPackage;
using Amazon.MediaPackage.Model;
using Amazon.Runtime;

namespace CloudOps.MediaPackage
{
    public class ListOriginEndpointsOperation : Operation
    {
        public override string Name => "ListOriginEndpoints";

        public override string Description => "Returns a collection of OriginEndpoint records.";
 
        public override string RequestURI => "/origin_endpoints";

        public override string Method => "GET";

        public override string ServiceName => "MediaPackage";

        public override string ServiceID => "MediaPackage";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonMediaPackageClient client = new AmazonMediaPackageClient(creds, region);
            ListOriginEndpointsResponse resp = new ListOriginEndpointsResponse();
            do
            {
                ListOriginEndpointsRequest req = new ListOriginEndpointsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListOriginEndpoints(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.OriginEndpoints)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}