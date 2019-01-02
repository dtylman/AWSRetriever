using Amazon;
using Amazon.Glacier;
using Amazon.Glacier.Model;
using Amazon.Runtime;

namespace CloudOps.Glacier
{
    public class ListJobsOperation : Operation
    {
        public override string Name => "ListJobs";

        public override string Description => "This operation lists jobs for a vault, including jobs that are in-progress and jobs that have recently finished. The List Job operation returns a list of these jobs sorted by job initiation time.  Amazon Glacier retains recently completed jobs for a period before deleting them; however, it eventually removes completed jobs. The output of completed jobs can be retrieved. Retaining completed jobs for a period of time after they have completed enables you to get a job output in the event you miss the job completion notification or your first attempt to download it fails. For example, suppose you start an archive retrieval job to download an archive. After the job completes, you start to download the archive but encounter a network error. In this scenario, you can retry and download the archive while the job exists.  The List Jobs operation supports pagination. You should always check the response Marker field. If there are no more jobs to list, the Marker field is set to null. If there are more jobs to list, the Marker field is set to a non-null value, which you can use to continue the pagination of the list. To return a list of jobs that begins at a specific job, set the marker request parameter to the Marker value for that job that you obtained from a previous List Jobs request. You can set a maximum limit for the number of jobs returned in the response by specifying the limit parameter in the request. The default limit is 50. The number of jobs returned might be fewer than the limit, but the number of returned jobs never exceeds the limit. Additionally, you can filter the jobs list returned by specifying the optional statuscode parameter or completed parameter, or both. Using the statuscode parameter, you can specify to return only jobs that match either the InProgress, Succeeded, or Failed status. Using the completed parameter, you can specify to return only jobs that were completed (true) or jobs that were not completed (false). For more information about using this operation, see the documentation for the underlying REST API List Jobs. ";
 
        public override string RequestURI => "/{accountId}/vaults/{vaultName}/jobs";

        public override string Method => "GET";

        public override string ServiceName => "Glacier";

        public override string ServiceID => "Glacier";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGlacierClient client = new AmazonGlacierClient(creds, region);
            ListJobsResponse resp = new ListJobsResponse();
            do
            {
                ListJobsRequest req = new ListJobsRequest
                {
                    Marker = resp.Marker
                    ,
                    Limit = maxItems
                                        
                };

                resp = client.ListJobs(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.JobList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}