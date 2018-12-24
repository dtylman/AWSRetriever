using Amazon;
using Amazon.RDS;
using Amazon.RDS.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class RDSDownloadDBLogFilePortionOperation : Operation
    {
        public override string Name => "DownloadDBLogFilePortion";

        public override string Description => "Downloads all or a portion of the specified log file, up to 1 MB in size.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "RDS";

        public override string ServiceID => "RDS";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonRDSClient client = new AmazonRDSClient(creds, region);
            DownloadDBLogFilePortionDetails resp = new DownloadDBLogFilePortionDetails();
            do
            {
                DownloadDBLogFilePortionMessage req = new DownloadDBLogFilePortionMessage
                {
                    Marker = resp.Marker,
                    NumberOfLines = maxItems
                };
                resp = client.DownloadDBLogFilePortion(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.LogFileData)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}