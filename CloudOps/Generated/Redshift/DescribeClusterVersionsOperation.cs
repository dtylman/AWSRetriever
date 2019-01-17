using Amazon;
using Amazon.Redshift;
using Amazon.Redshift.Model;
using Amazon.Runtime;

namespace CloudOps.Redshift
{
    public class DescribeClusterVersionsOperation : Operation
    {
        public override string Name => "DescribeClusterVersions";

        public override string Description => "Returns descriptions of the available Amazon Redshift cluster versions. You can call this operation even before creating any clusters to learn more about the Amazon Redshift versions. For more information about managing clusters, go to Amazon Redshift Clusters in the Amazon Redshift Cluster Management Guide.";
 
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
            
            DescribeClusterVersionsResponse resp = new DescribeClusterVersionsResponse();
            do
            {
                DescribeClusterVersionsRequest req = new DescribeClusterVersionsRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeClusterVersions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ClusterVersions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}