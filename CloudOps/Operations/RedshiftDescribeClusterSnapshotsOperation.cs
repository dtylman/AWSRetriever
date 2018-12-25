using Amazon;
using Amazon.Redshift;
using Amazon.Redshift.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RedshiftDescribeClusterSnapshotsOperation : Operation
    {
        public override string Name => "DescribeClusterSnapshots";

        public override string Description => "Returns one or more snapshot objects, which contain metadata about your cluster snapshots. By default, this operation returns information about all snapshots of all clusters that are owned by you AWS customer account. No information is returned for snapshots owned by inactive AWS customer accounts. If you specify both tag keys and tag values in the same request, Amazon Redshift returns all snapshots that match any combination of the specified keys and values. For example, if you have owner and environment for tag keys, and admin and test for tag values, all snapshots that have any combination of those values are returned. Only snapshots that you own are returned in the response; shared snapshots are not returned with the tag key and tag value request parameters. If both tag keys and values are omitted from the request, snapshots are returned regardless of whether they have tag keys or values associated with them.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Redshift";

        public override string ServiceID => "Redshift";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRedshiftClient client = new AmazonRedshiftClient(creds, region);
            SnapshotMessage resp = new SnapshotMessage();
            do
            {
                DescribeClusterSnapshotsMessage req = new DescribeClusterSnapshotsMessage
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeClusterSnapshots(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Snapshots)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}