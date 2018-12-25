using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RDSDescribeDBSubnetGroupsOperation : Operation
    {
        public override string Name => "DescribeDBSubnetGroups";

        public override string Description => "Returns a list of DBSubnetGroup descriptions. If a DBSubnetGroupName is specified, the list will contain only the descriptions of the specified DBSubnetGroup. For an overview of CIDR ranges, go to the Wikipedia Tutorial. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            DBSubnetGroupMessage resp = new DBSubnetGroupMessage();
            do
            {
                DescribeDBSubnetGroupsMessage req = new DescribeDBSubnetGroupsMessage
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeDBSubnetGroups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DBSubnetGroups)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}