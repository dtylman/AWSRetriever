using System;
using Amazon;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Amazon.Runtime;

namespace heaven
{
    internal class ResourceLister
    {
        private AppLogger log = AppLogger.GetLogger();

        private string _accessKey;
        private string _secretKey;
        private int _maxItems = 100;

        internal void List()
        {
            log.Print("Listing...");
            AWSCredentials credentials = null;
            if (!string.IsNullOrEmpty(this._accessKey))
            {
                credentials = new BasicAWSCredentials(this._accessKey, this._secretKey);
            }
            else
            {
                credentials = FallbackCredentialsFactory.GetCredentials();
            }

            foreach (RegionEndpoint region in RegionEndpoint.EnumerableAllRegions) {
                try
                {
                    log.Printf("Reading from {0}...", region);
                    AmazonLambdaClient client = new AmazonLambdaClient(credentials, region);
                    ListFunctionsResponse resp = new ListFunctionsResponse();
                    ListFunctionsRequest req = new ListFunctionsRequest
                    {
                        Marker = resp.NextMarker,
                        MaxItems = this._maxItems
                    };
                    do
                    {
                        resp = client.ListFunctions(req);
                        foreach (FunctionConfiguration func in resp.Functions)
                        {
                            AWSObject awsObject = new AWSObject
                            {
                                Region = region,
                                Arn = func.FunctionArn,
                                Description = func.Description,
                                LastModified = func.LastModified,
                                Version = func.Version,
                                Role = func.Role,
                                Object = func, 
                            };
                            log.Print(awsObject);
                        }
                    }
                    while (!string.IsNullOrEmpty(resp.NextMarker));
                }
                catch (Exception ex)
                {
                    log.Print(ex);
                }
            }
        }
    }
}