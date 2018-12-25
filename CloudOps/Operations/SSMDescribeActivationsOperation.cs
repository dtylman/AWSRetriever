using Amazon;
using Amazon.SSM;
using Amazon.SSM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SSMDescribeActivationsOperation : Operation
    {
        public override string Name => "DescribeActivations";

        public override string Description => "Details about the activation, including: the date and time the activation was created, the expiration date, the IAM role assigned to the instances in the activation, and the number of instances activated by this registration.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SSM";

        public override string ServiceID => "SSM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSSMClient client = new AmazonSSMClient(creds, region);
            DescribeActivationsResult resp = new DescribeActivationsResult();
            do
            {
                DescribeActivationsRequest req = new DescribeActivationsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeActivations(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ActivationList)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}