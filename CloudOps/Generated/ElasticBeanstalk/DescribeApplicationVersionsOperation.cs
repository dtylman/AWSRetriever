using Amazon;
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;
using Amazon.Runtime;

namespace CloudOps.ElasticBeanstalk
{
    public class DescribeApplicationVersionsOperation : Operation
    {
        public override string Name => "DescribeApplicationVersions";

        public override string Description => "Retrieve a list of application versions.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElasticBeanstalk";

        public override string ServiceID => "Elastic Beanstalk";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticBeanstalkClient client = new AmazonElasticBeanstalkClient(creds, region);
            DescribeApplicationVersionsResponse resp = new DescribeApplicationVersionsResponse();
            DescribeApplicationVersionsRequest req = new DescribeApplicationVersionsRequest
            {                    
                                    
            };
            resp = client.DescribeApplicationVersions(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.ApplicationVersions)
            {
                AddObject(obj);
            }
            
        }
    }
}