using Amazon;
using Amazon.IAM;
using Amazon.IAM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IAMListMFADevicesOperation : Operation
    {
        public override string Name => "ListMFADevices";

        public override string Description => "Lists the MFA devices for an IAM user. If the request includes a IAM user name, then this operation lists all the MFA devices associated with the specified user. If you do not specify a user name, IAM determines the user name implicitly based on the AWS access key ID signing the request for this API. You can paginate the results using the MaxItems and Marker parameters.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "IAM";

        public override string ServiceID => "IAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIAMClient client = new AmazonIAMClient(creds, region);
            ListMFADevicesResponse resp = new ListMFADevicesResponse();
            do
            {
                ListMFADevicesRequest req = new ListMFADevicesRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListMFADevices(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.MFADevices)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}