using Amazon;
using Amazon.Redshift;
using Amazon.Redshift.Model;
using Amazon.Runtime;

namespace CloudOps.Redshift
{
    public class DescribeDefaultClusterParametersOperation : Operation
    {
        public override string Name => "DescribeDefaultClusterParameters";

        public override string Description => "Returns a list of parameter settings for the specified parameter group family.  For more information about parameters and parameter groups, go to Amazon Redshift Parameter Groups in the Amazon Redshift Cluster Management Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Redshift";

        public override string ServiceID => "Redshift";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRedshiftConfig config = new AmazonRedshiftConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonRedshiftClient client = new AmazonRedshiftClient(creds, config);
            
            DescribeDefaultClusterParametersResponse resp = new DescribeDefaultClusterParametersResponse();
            do
            {
                DescribeDefaultClusterParametersRequest req = new DescribeDefaultClusterParametersRequest
                {
                    Marker = resp.DefaultClusterParameters.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeDefaultClusterParameters(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DefaultClusterParameters.Parameters)
                {
                    AddObject(obj);
                }
            }           
                
while (!string.IsNullOrEmpty(resp.DefaultClusterParameters.Marker));        }
    }
}