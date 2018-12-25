using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RDSDescribeDBSecurityGroupsOperation : Operation
    {
        public override string Name => "DescribeDBSecurityGroups";

        public override string Description => " Returns a list of DBSecurityGroup descriptions. If a DBSecurityGroupName is specified, the list will contain only the descriptions of the specified DB security group. ";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            DBSecurityGroupMessage resp = new DBSecurityGroupMessage();
            do
            {
                DescribeDBSecurityGroupsMessage req = new DescribeDBSecurityGroupsMessage
                {
                    Marker = resp.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeDBSecurityGroups(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DBSecurityGroups)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}