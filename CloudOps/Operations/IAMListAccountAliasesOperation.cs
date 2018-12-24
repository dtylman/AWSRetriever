using Amazon;
using Amazon.IAM;
using Amazon.IAM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IAMListAccountAliasesOperation : Operation
    {
        public override string Name => "ListAccountAliases";

        public override string Description => "Lists the account alias associated with the AWS account (Note: you can have only one). For information about using an AWS account alias, see Using an Alias for Your AWS Account ID in the IAM User Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "IAM";

        public override string ServiceID => "IAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIAMClient client = new AmazonIAMClient(creds, region);
            ListAccountAliasesResponse resp = new ListAccountAliasesResponse();
            do
            {
                ListAccountAliasesRequest req = new ListAccountAliasesRequest
                {
                    Marker = resp.Marker,
                    MaxItems = maxItems
                };
                resp = client.ListAccountAliases(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.AccountAliases)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}