using Amazon;
using Amazon.Redshift;
using Amazon.Redshift.Model;
using Amazon.Runtime;

namespace CloudOps.Redshift
{
    public class DescribeReservedNodesOperation : Operation
    {
        public override string Name => "DescribeReservedNodes";

        public override string Description => "Returns the descriptions of the reserved nodes.";
 
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
            
            DescribeReservedNodesResponse resp = new DescribeReservedNodesResponse();
            do
            {
                DescribeReservedNodesRequest req = new DescribeReservedNodesRequest
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