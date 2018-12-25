using Amazon;
using Amazon.FSx;
using Amazon.FSx.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class FSxDescribeBackupsOperation : Operation
    {
        public override string Name => "DescribeBackups";

        public override string Description => "Returns the description of specific Amazon FSx for Windows File Server backups, if a BackupIds value is provided for that backup. Otherwise, it returns all backups owned by your AWS account in the AWS Region of the endpoint that you&#39;re calling. When retrieving all backups, you can optionally specify the MaxResults parameter to limit the number of backups in a response. If more backups remain, Amazon FSx returns a NextToken value in the response. In this case, send a later request with the NextToken request parameter set to the value of NextToken from the last response. This action is used in an iterative process to retrieve a list of your backups. DescribeBackups is called first without a NextTokenvalue. Then the action continues to be called with the NextToken parameter set to the value of the last NextToken value until a response has no NextToken. When using this action, keep the following in mind:   The implementation might return fewer than MaxResults file system descriptions while still including a NextToken value.   The order of backups returned in the response of one DescribeBackups call and the order of backups returned across the responses of a multi-call iteration is unspecified.  ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "FSx";

        public override string ServiceID => "FSx";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonFSxClient client = new AmazonFSxClient(creds, region);
            DescribeBackupsResponse resp = new DescribeBackupsResponse();
            do
            {
                DescribeBackupsRequest req = new DescribeBackupsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeBackups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Backups)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}