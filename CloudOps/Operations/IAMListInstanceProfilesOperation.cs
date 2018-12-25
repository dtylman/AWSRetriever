using Amazon;
using Amazon.IAM;
using Amazon.IAM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IAMListInstanceProfilesOperation : Operation
    {
        public override string Name => "ListInstanceProfiles";

        public override string Description => "Lists the instance profiles that have the specified path prefix. If there are none, the operation returns an empty list. For more information about instance profiles, go to About Instance Profiles. You can paginate the results using the MaxItems and Marker parameters.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "IAM";

        public override string ServiceID => "IAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIAMClient client = new AmazonIAMClient(creds, region);
            ListInstanceProfilesResponse resp = new ListInstanceProfilesResponse();
            do
            {
                ListInstanceProfilesRequest req = new ListInstanceProfilesRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.ListInstanceProfiles(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.InstanceProfiles)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}