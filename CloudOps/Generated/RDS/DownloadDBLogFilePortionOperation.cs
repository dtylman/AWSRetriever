using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.RDS
{
    public class DownloadDBLogFilePortionOperation : Operation
    {
        public override string Name => "DownloadDBLogFilePortion";

        public override string Description => "Downloads all or a portion of the specified log file, up to 1 MB in size.";
 
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
            
            DownloadDBLogFilePortionResponse resp = new DownloadDBLogFilePortionResponse();
            do
            {
                DownloadDBLogFilePortionRequest req = new DownloadDBLogFilePortionRequest
                {
                    Marker = resp.Marker
                    ,
                    NumberOfLines = maxItems
                                        
                };

                resp = client.DownloadDBLogFilePortion(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.LogFileData)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}