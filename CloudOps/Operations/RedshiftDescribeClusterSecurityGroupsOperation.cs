using Amazon;
using Amazon.Redshift;
using Amazon.Redshift.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RedshiftDescribeClusterSecurityGroupsOperation : Operation
    {
        public override string Name => "DescribeClusterSecurityGroups";

        public override string Description => "Returns information about Amazon Redshift security groups. If the name of a security group is specified, the response will contain only information about only that security group.  For information about managing security groups, go to Amazon Redshift Cluster Security Groups in the Amazon Redshift Cluster Management Guide. If you specify both tag keys and tag values in the same request, Amazon Redshift returns all security groups that match any combination of the specified keys and values. For example, if you have owner and environment for tag keys, and admin and test for tag values, all security groups that have any combination of those values are returned. If both tag keys and values are omitted from the request, security groups are returned regardless of whether they have tag keys or values associated with them.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Redshift";

        public override string ServiceID => "Redshift";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRedshiftClient client = new AmazonRedshiftClient(creds, region);
            ClusterSecurityGroupMessage resp = new ClusterSecurityGroupMessage();
            do
            {
                DescribeClusterSecurityGroupsMessage req = new DescribeClusterSecurityGroupsMessage
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeClusterSecurityGroups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.ClusterSecurityGroups)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}