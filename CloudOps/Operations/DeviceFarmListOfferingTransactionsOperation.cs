using Amazon;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DeviceFarmListOfferingTransactionsOperation : Operation
    {
        public override string Name => "ListOfferingTransactions";

        public override string Description => "Returns a list of all historical purchases, renewals, and system renewal transactions for an AWS account. The list is paginated and ordered by a descending timestamp (most recent transactions are first). The API returns a NotEligible error if the user is not permitted to invoke the operation. Please contact aws-devicefarm-support@amazon.com if you believe that you should be able to invoke this operation.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "DeviceFarm";

        public override string ServiceID => "Device Farm";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDeviceFarmClient client = new AmazonDeviceFarmClient(creds, region);
            ListOfferingTransactionsResult resp = new ListOfferingTransactionsResult();
            do
            {
                ListOfferingTransactionsRequest req = new ListOfferingTransactionsRequest
                {
                    nextToken = resp.nextToken
                                        
                };

                resp = client.ListOfferingTransactions(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.offeringTransactions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}