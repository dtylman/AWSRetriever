using Amazon;
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;
using Amazon.Runtime;

namespace CloudOps.ElasticBeanstalk
{
    public class ListAvailableSolutionStacksOperation : Operation
    {
        public override string Name => "ListAvailableSolutionStacks";

        public override string Description => "Returns a list of the available solution stack names, with the public version first and then in reverse chronological order.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElasticBeanstalk";

        public override string ServiceID => "Elastic Beanstalk";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElasticBeanstalkClient client = new AmazonElasticBeanstalkClient(creds, region);
            ListAvailableSolutionStacksResponse resp = new ListAvailableSolutionStacksResponse();
            ListAvailableSolutionStacksRequest req = new ListAvailableSolutionStacksRequest
            {                    
                                    
            };
            resp = client.ListAvailableSolutionStacks(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.SolutionStacks)
            {
                AddObject(obj);
            }
            
        }
    }
}