using Amazon;
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElasticBeanstalkDescribeApplicationsOperation : Operation
    {
        public override string Name => "DescribeApplications";

        public override string Description => "Returns the descriptions of existing applications.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElasticBeanstalk";

        public override string ServiceID => "Elastic Beanstalk";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticBeanstalkClient client = new AmazonElasticBeanstalkClient(creds, region);
            ApplicationDescriptionsMessage resp = new ApplicationDescriptionsMessage();
            do
            {
                DescribeApplicationsMessage req = new DescribeApplicationsMessage
                {
                    &lt;nil&gt; = resp.&lt;nil&gt;
                                        
                };

                resp = client.DescribeApplications(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Applications)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.&lt;nil&gt;));
        }
    }
}