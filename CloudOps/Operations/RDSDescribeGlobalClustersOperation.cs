using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RDSDescribeGlobalClustersOperation : Operation
    {
        public override string Name => "DescribeGlobalClusters";

        public override string Description => " Returns information about Aurora global database clusters. This API supports pagination.   For more information on Amazon Aurora, see  What Is Amazon Aurora? in the Amazon Aurora User Guide. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            GlobalClustersMessage resp = new GlobalClustersMessage();
            do
            {
                DescribeGlobalClustersMessage req = new DescribeGlobalClustersMessage
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeGlobalClusters(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.GlobalClusters)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}