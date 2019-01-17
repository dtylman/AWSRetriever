using Amazon;
using Amazon.Glue;
using Amazon.Glue.Model;
using Amazon.Runtime;

namespace CloudOps.Glue
{
    public class GetClassifiersOperation : Operation
    {
        public override string Name => "GetClassifiers";

        public override string Description => "Lists all classifier objects in the Data Catalog.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Glue";

        public override string ServiceID => "Glue";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonGlueConfig config = new AmazonGlueConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonGlueClient client = new AmazonGlueClient(creds, config);
            
            GetClassifiersResponse resp = new GetClassifiersResponse();
            do
            {
                GetClassifiersRequest req = new GetClassifiersRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.GetClassifiers(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Classifiers)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}