using Amazon;
using Amazon.MediaConvert;
using Amazon.MediaConvert.Model;
using Amazon.Runtime;

namespace CloudOps.MediaConvert
{
    public class ListPresetsOperation : Operation
    {
        public override string Name => "ListPresets";

        public override string Description => "Retrieve a JSON array of up to twenty of your presets. This will return the presets themselves, not just a list of them. To retrieve the next twenty presets, use the nextToken string returned with the array.";
 
        public override string RequestURI => "/2017-08-29/presets";

        public override string Method => "GET";

        public override string ServiceName => "MediaConvert";

        public override string ServiceID => "MediaConvert";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonMediaConvertConfig config = new AmazonMediaConvertConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonMediaConvertClient client = new AmazonMediaConvertClient(creds, config);
            
            ListPresetsResponse resp = new ListPresetsResponse();
            do
            {
                ListPresetsRequest req = new ListPresetsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListPresets(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Presets)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}