using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.RDS
{
    public class DescribeEngineDefaultParametersOperation : Operation
    {
        public override string Name => "DescribeEngineDefaultParameters";

        public override string Description => "";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            DescribeEngineDefaultParametersResponse resp = new DescribeEngineDefaultParametersResponse();
            do
            {
                DescribeEngineDefaultParametersRequest req = new DescribeEngineDefaultParametersRequest
                {
                    Marker = resp.EngineDefaultsMarker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeEngineDefaultParameters(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.EngineDefaultsParameters)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.EngineDefaultsMarker));
        }
    }
}