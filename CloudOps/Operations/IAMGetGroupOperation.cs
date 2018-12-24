using Amazon;
using Amazon.IAM;
using Amazon.IAM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IAMGetGroupOperation : Operation
    {
        public override string Name => "GetGroup";

        public override string Description => " Returns a list of IAM users that are in the specified IAM group. You can paginate the results using the MaxItems and Marker parameters.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "IAM";

        public override string ServiceID => "IAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIAMClient client = new AmazonIAMClient(creds, region);
            GetGroupResponse resp = new GetGroupResponse();
            do
            {
                GetGroupRequest req = new GetGroupRequest
                {
                    Marker = resp.Marker,
                    MaxItems = maxItems
                };
                resp = client.GetGroup(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Users)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}