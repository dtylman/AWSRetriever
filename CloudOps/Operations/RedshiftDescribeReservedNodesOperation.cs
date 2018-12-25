using Amazon;
using Amazon.Redshift;
using Amazon.Redshift.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RedshiftDescribeReservedNodesOperation : Operation
    {
        public override string Name => "DescribeReservedNodes";

        public override string Description => "Returns the descriptions of the reserved nodes.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Redshift";

        public override string ServiceID => "Redshift";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRedshiftClient client = new AmazonRedshiftClient(creds, region);
            ReservedNodesMessageResponse resp = new ReservedNodesMessageResponse();
            do
            {
                DescribeReservedNodesMessageRequest req = new DescribeReservedNodesMessageRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeReservedNodes(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ReservedNodes)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}