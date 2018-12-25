using Amazon;
using Amazon.Signer;
using Amazon.Signer.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SignerListSigningProfilesOperation : Operation
    {
        public override string Name => "ListSigningProfiles";

        public override string Description => "Lists all available signing profiles in your AWS account. Returns only profiles with an ACTIVE status unless the includeCanceled request field is set to true. If additional jobs remain to be listed, AWS Signer returns a nextToken value. Use this value in subsequent calls to ListSigningJobs to fetch the remaining values. You can continue calling ListSigningJobs with your maxResults parameter and with new values that AWS Signer returns in the nextToken parameter until all of your signing jobs have been returned.";
 
        public override string RequestURI => "/signing-profiles";

        public override string Method => "GET";

        public override string ServiceName => "Signer";

        public override string ServiceID => "signer";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSignerClient client = new AmazonSignerClient(creds, region);
            ListSigningProfilesResponse resp = new ListSigningProfilesResponse();
            do
            {
                ListSigningProfilesRequest req = new ListSigningProfilesRequest
                {
                    nextToken = resp.nextToken
                    ,
                    maxResults = maxItems
                                        
                };

                resp = client.ListSigningProfiles(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.profiles)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}