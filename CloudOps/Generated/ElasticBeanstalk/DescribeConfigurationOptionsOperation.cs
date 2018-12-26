using Amazon;
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;
using Amazon.Runtime;

namespace CloudOps.ElasticBeanstalk
{
    public class DescribeConfigurationOptionsOperation : Operation
    {
        public override string Name => "DescribeConfigurationOptions";

        public override string Description => "Describes the configuration options that are used in a particular configuration template or environment, or that a specified solution stack defines. The description includes the values the options, their default values, and an indication of the required action on a running environment if an option value is changed.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElasticBeanstalk";

        public override string ServiceID => "Elastic Beanstalk";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticBeanstalkClient client = new AmazonElasticBeanstalkClient(creds, region);
            DescribeConfigurationOptionsResponse resp = new DescribeConfigurationOptionsResponse();
            DescribeConfigurationOptionsRequest req = new DescribeConfigurationOptionsRequest
            {                    
                                    
            };
            resp = client.DescribeConfigurationOptions(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.Options)
            {
                AddObject(obj);
            }
            
        }
    }
}