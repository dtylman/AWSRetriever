using Amazon;
using Amazon.FSx;
using Amazon.FSx.Model;
using Amazon.Runtime;

namespace CloudOps.FSx
{
    public class DescribeFileSystemsOperation : Operation
    {
        public override string Name => "DescribeFileSystems";

        public override string Description => "Returns the description of specific Amazon FSx file systems, if a FileSystemIds value is provided for that file system. Otherwise, it returns descriptions of all file systems owned by your AWS account in the AWS Region of the endpoint that you&#39;re calling. When retrieving all file system descriptions, you can optionally specify the MaxResults parameter to limit the number of descriptions in a response. If more file system descriptions remain, Amazon FSx returns a NextToken value in the response. In this case, send a later request with the NextToken request parameter set to the value of NextToken from the last response. This action is used in an iterative process to retrieve a list of your file system descriptions. DescribeFileSystems is called first without a NextTokenvalue. Then the action continues to be called with the NextToken parameter set to the value of the last NextToken value until a response has no NextToken. When using this action, keep the following in mind:   The implementation might return fewer than MaxResults file system descriptions while still including a NextToken value.   The order of file systems returned in the response of one DescribeFileSystems call and the order of file systems returned across the responses of a multicall iteration is unspecified.  ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "FSx";

        public override string ServiceID => "FSx";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonFSxConfig config = new AmazonFSxConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonFSxClient client = new AmazonFSxClient(creds, config);
            
            DescribeFileSystemsResponse resp = new DescribeFileSystemsResponse();
            do
            {
                DescribeFileSystemsRequest req = new DescribeFileSystemsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeFileSystems(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.FileSystems)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}