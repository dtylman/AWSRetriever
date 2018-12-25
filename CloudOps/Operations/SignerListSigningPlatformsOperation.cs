using Amazon;
using Amazon.Signer;
using Amazon.Signer.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SignerListSigningPlatformsOperation : Operation
    {
        public override string Name => "ListSigningPlatforms";

        public override string Description => "Lists all signing platforms available in AWS Signer that match the request parameters. If additional jobs remain to be listed, AWS Signer returns a nextToken value. Use this value in subsequent calls to ListSigningJobs to fetch the remaining values. You can continue calling ListSigningJobs with your maxResults parameter and with new values that AWS Signer returns in the nextToken parameter until all of your signing jobs have been returned.";
 
        public override string RequestURI => "/signing-platforms";

        public override string Method => "GET";

        public override string ServiceName => "Signer";

        public override string ServiceID => "signer";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSignerClient client = new AmazonSignerClient(creds, region);
            ListSigningPlatformsResponse resp = new ListSigningPlatformsResponse();
            do
            {
                ListSigningPlatformsRequest req = new ListSigningPlatformsRequest
                {
                    nextToken = resp.nextToken
                    ,
                    maxResults = maxItems
                                        
                };

                resp = client.ListSigningPlatforms(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}