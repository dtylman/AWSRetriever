using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RDSDescribeDBClustersOperation : Operation
    {
        public override string Name => "DescribeDBClusters";

        public override string Description => "Returns information about provisioned Aurora DB clusters. This API supports pagination. For more information on Amazon Aurora, see  What Is Amazon Aurora? in the Amazon Aurora User Guide. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            DBClusterMessageResponse resp = new DBClusterMessageResponse();
            do
            {
                DescribeDBClustersMessageRequest req = new DescribeDBClustersMessageRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeDBClusters(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DBClusters)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}