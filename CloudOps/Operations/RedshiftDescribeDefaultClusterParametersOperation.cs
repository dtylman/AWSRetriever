using Amazon;
using Amazon.Redshift;
using Amazon.Redshift.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RedshiftDescribeDefaultClusterParametersOperation : Operation
    {
        public override string Name => "DescribeDefaultClusterParameters";

        public override string Description => "Returns a list of parameter settings for the specified parameter group family.  For more information about parameters and parameter groups, go to Amazon Redshift Parameter Groups in the Amazon Redshift Cluster Management Guide.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "Redshift";

        public override string ServiceID => "Redshift";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRedshiftClient client = new AmazonRedshiftClient(creds, region);
            Response resp = new Response();
            do
            {
                DescribeDefaultClusterParametersMessageRequest req = new DescribeDefaultClusterParametersMessageRequest
                {
                    Marker = resp.DefaultClusterParametersMarker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeDefaultClusterParameters(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DefaultClusterParametersParameters)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.DefaultClusterParametersMarker));
        }
    }
}