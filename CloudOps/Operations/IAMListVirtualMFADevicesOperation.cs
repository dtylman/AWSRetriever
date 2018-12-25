using Amazon;
using Amazon.IAM;
using Amazon.IAM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IAMListVirtualMFADevicesOperation : Operation
    {
        public override string Name => "ListVirtualMFADevices";

        public override string Description => "Lists the virtual MFA devices defined in the AWS account by assignment status. If you do not specify an assignment status, the operation returns a list of all virtual MFA devices. Assignment status can be Assigned, Unassigned, or Any. You can paginate the results using the MaxItems and Marker parameters.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "IAM";

        public override string ServiceID => "IAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIAMClient client = new AmazonIAMClient(creds, region);
            ListVirtualMFADevicesResponse resp = new ListVirtualMFADevicesResponse();
            do
            {
                ListVirtualMFADevicesRequest req = new ListVirtualMFADevicesRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListVirtualMFADevices(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.VirtualMFADevices)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}