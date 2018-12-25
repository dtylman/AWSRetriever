using Amazon;
using Amazon.SSM;
using Amazon.SSM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SSMListDocumentsOperation : Operation
    {
        public override string Name => "ListDocuments";

        public override string Description => "Describes one or more of your Systems Manager documents.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SSM";

        public override string ServiceID => "SSM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSSMClient client = new AmazonSSMClient(creds, region);
            ListDocumentsResult resp = new ListDocumentsResult();
            do
            {
                ListDocumentsRequest req = new ListDocumentsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListDocuments(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.DocumentIdentifiers)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}