using Amazon;
using Amazon.IAM;
using Amazon.IAM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IAMGetAccountAuthorizationDetailsOperation : Operation
    {
        public override string Name => "GetAccountAuthorizationDetails";

        public override string Description => "Retrieves information about all IAM users, groups, roles, and policies in your AWS account, including their relationships to one another. Use this API to obtain a snapshot of the configuration of IAM permissions (users, groups, roles, and policies) in your account.  Policies returned by this API are URL-encoded compliant with RFC 3986. You can use a URL decoding method to convert the policy back to plain JSON text. For example, if you use Java, you can use the decode method of the java.net.URLDecoder utility class in the Java SDK. Other languages and SDKs provide similar functionality.  You can optionally filter the results using the Filter parameter. You can paginate the results using the MaxItems and Marker parameters.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "IAM";

        public override string ServiceID => "IAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIAMClient client = new AmazonIAMClient(creds, region);
            GetAccountAuthorizationDetailsResponse resp = new GetAccountAuthorizationDetailsResponse();
            do
            {
                GetAccountAuthorizationDetailsRequest req = new GetAccountAuthorizationDetailsRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.GetAccountAuthorizationDetails(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.[UserDetailList GroupDetailList RoleDetailList Policies])
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}