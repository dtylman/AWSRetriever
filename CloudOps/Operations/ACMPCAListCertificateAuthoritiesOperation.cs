using Amazon;
using Amazon.ACMPCA;
using Amazon.ACMPCA.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ACMPCAListCertificateAuthoritiesOperation : Operation
    {
        public override string Name => "ListCertificateAuthorities";

        public override string Description => "Lists the private certificate authorities that you created by using the CreateCertificateAuthority operation.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ACMPCA";

        public override string ServiceID => "ACM PCA";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonACMPCAClient client = new AmazonACMPCAClient(creds, region);
            ListCertificateAuthoritiesResponse resp = new ListCertificateAuthoritiesResponse();
            do
            {
                ListCertificateAuthoritiesRequest req = new ListCertificateAuthoritiesRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListCertificateAuthorities(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.CertificateAuthorities)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}