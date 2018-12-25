using Amazon;
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElasticBeanstalkDescribeEnvironmentsOperation : Operation
    {
        public override string Name => "DescribeEnvironments";

        public override string Description => "Returns descriptions for existing environments.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElasticBeanstalk";

        public override string ServiceID => "Elastic Beanstalk";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticBeanstalkClient client = new AmazonElasticBeanstalkClient(creds, region);
            EnvironmentDescriptionsMessageResponse resp = new EnvironmentDescriptionsMessageResponse();
            DescribeEnvironmentsMessageRequest req = new DescribeEnvironmentsMessageRequest
            {                    
                                    
            };
            resp = client.DescribeEnvironments(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.Environments)
            {
                AddObject(obj);
            }
            
        }
    }
}