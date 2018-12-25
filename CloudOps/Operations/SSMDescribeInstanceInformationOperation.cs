using Amazon;
using Amazon.SSM;
using Amazon.SSM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SSMDescribeInstanceInformationOperation : Operation
    {
        public override string Name => "DescribeInstanceInformation";

        public override string Description => "Describes one or more of your instances. You can use this to get information about instances like the operating system platform, the SSM Agent version (Linux), status etc. If you specify one or more instance IDs, it returns information for those instances. If you do not specify instance IDs, it returns information for all your instances. If you specify an instance ID that is not valid or an instance that you do not own, you receive an error.   The IamRole field for this API action is the Amazon Identity and Access Management (IAM) role assigned to on-premises instances. This call does not return the IAM role for Amazon EC2 instances. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SSM";

        public override string ServiceID => "SSM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSSMClient client = new AmazonSSMClient(creds, region);
            DescribeInstanceInformationResult resp = new DescribeInstanceInformationResult();
            do
            {
                DescribeInstanceInformationRequest req = new DescribeInstanceInformationRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeInstanceInformation(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.InstanceInformationList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}