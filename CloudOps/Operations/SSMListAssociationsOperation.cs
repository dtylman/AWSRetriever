using Amazon;
using Amazon.SSM;
using Amazon.SSM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SSMListAssociationsOperation : Operation
    {
        public override string Name => "ListAssociations";

        public override string Description => "Lists the associations for the specified Systems Manager document or instance.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SSM";

        public override string ServiceID => "SSM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSSMClient client = new AmazonSSMClient(creds, region);
            ListAssociationsResult resp = new ListAssociationsResult();
            do
            {
                ListAssociationsRequest req = new ListAssociationsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListAssociations(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Associations)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}