using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RDSDescribeDBSnapshotsOperation : Operation
    {
        public override string Name => "DescribeDBSnapshots";

        public override string Description => "Returns information about DB snapshots. This API action supports pagination.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            DBSnapshotMessageResponse resp = new DBSnapshotMessageResponse();
            do
            {
                DescribeDBSnapshotsMessageRequest req = new DescribeDBSnapshotsMessageRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeDBSnapshots(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DBSnapshots)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}