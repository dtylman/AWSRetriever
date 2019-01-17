using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.RDS
{
    public class DescribeEngineDefaultParametersOperation : Operation
    {
        public override string Name => "DescribeEngineDefaultParameters";

        public override string Description => "Returns the default engine and system parameter information for the specified database engine.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSConfig config = new AmazonRDSConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonRDSClient client = new AmazonRDSClient(creds, config);
            
            DescribeEngineDefaultParametersResponse resp = new DescribeEngineDefaultParametersResponse();
            do
            {
                DescribeEngineDefaultParametersRequest req = new DescribeEngineDefaultParametersRequest
                {
                    Marker = resp.EngineDefaults.Marker
                    ,
                    MaxRecords = maxItems
                                        
                };

                resp = client.DescribeEngineDefaultParameters(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.EngineDefaults.Parameters)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.EngineDefaults.Marker));
        }
    }
}