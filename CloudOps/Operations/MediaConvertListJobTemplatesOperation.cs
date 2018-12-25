using Amazon;
using Amazon.MediaConvert;
using Amazon.MediaConvert.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class MediaConvertListJobTemplatesOperation : Operation
    {
        public override string Name => "ListJobTemplates";

        public override string Description => "Retrieve a JSON array of up to twenty of your job templates. This will return the templates themselves, not just a list of them. To retrieve the next twenty templates, use the nextToken string returned with the array";
 
        public override string RequestURI => "/2017-08-29/jobTemplates";

        public override string Method => "GET";

        public override string ServiceName => "MediaConvert";

        public override string ServiceID => "MediaConvert";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonMediaConvertClient client = new AmazonMediaConvertClient(creds, region);
            ListJobTemplatesResponse resp = new ListJobTemplatesResponse();
            do
            {
                ListJobTemplatesRequest req = new ListJobTemplatesRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListJobTemplates(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.JobTemplates)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}