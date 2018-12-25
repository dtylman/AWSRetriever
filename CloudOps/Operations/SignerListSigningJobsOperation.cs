using Amazon;
using Amazon.Signer;
using Amazon.Signer.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SignerListSigningJobsOperation : Operation
    {
        public override string Name => "ListSigningJobs";

        public override string Description => "Lists all your signing jobs. You can use the maxResults parameter to limit the number of signing jobs that are returned in the response. If additional jobs remain to be listed, AWS Signer returns a nextToken value. Use this value in subsequent calls to ListSigningJobs to fetch the remaining values. You can continue calling ListSigningJobs with your maxResults parameter and with new values that AWS Signer returns in the nextToken parameter until all of your signing jobs have been returned. ";
 
        public override string RequestURI => "/signing-jobs";

        public override string Method => "GET";

        public override string ServiceName => "Signer";

        public override string ServiceID => "signer";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSignerClient client = new AmazonSignerClient(creds, region);
            ListSigningJobsResponse resp = new ListSigningJobsResponse();
            do
            {
                ListSigningJobsRequest req = new ListSigningJobsRequest
                {
                    nextToken = resp.nextToken
                    ,
                    maxResults = maxItems
                                        
                };

                resp = client.ListSigningJobs(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.jobs)
                {
                    AddObject(obj);
                }
                
                foreach (var obj in resp.nextToken)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}