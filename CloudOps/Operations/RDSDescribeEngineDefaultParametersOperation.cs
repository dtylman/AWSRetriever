using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RDSDescribeEngineDefaultParametersOperation : Operation
    {
        public override string Name => "DescribeEngineDefaultParameters";

        public override string Description => "Returns the default engine and system parameter information for the specified database engine.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            Response resp = new Response();
            do
            {
                DescribeEngineDefaultParametersMessageRequest req = new DescribeEngineDefaultParametersMessageRequest
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