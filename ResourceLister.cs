using System;
using System.Collections.Generic;
using Amazon;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Amazon.Runtime;
using heaven.APIs;

namespace heaven
{
    internal class ResourceLister
    {
        private AppLogger log = AppLogger.GetLogger();
        private readonly List<AWSAPI> apis = new List<AWSAPI>();
        private string accessKey;
        private string secretKey;
        private int maxItems = 100;
        private readonly List<AWSObject> objects = new List<AWSObject>();

        public ResourceLister()
        {
            this.apis.Add(new AWSLambdaAPI(this.objects,this.maxItems));
        }

        public void List()
        {
            this.objects.Clear();
            AWSCredentials creds = GetCredentials();
            foreach (AWSAPI api in this.apis)
            {
                foreach (RegionEndpoint region in RegionEndpoint.EnumerableAllRegions)
                {
                    log.Printf("Fetching {1} from {0}...", api.Name, region);
                    try
                    {
                        api.Read(creds, region);
                    }
                    catch (Exception ex)
                    {
                        log.Print(ex);
                    }
                }
            }
        }

        private AWSCredentials GetCredentials()
        {
            if (!string.IsNullOrEmpty(this.accessKey))
            {
                return new BasicAWSCredentials(this.accessKey, this.secretKey);
            }
            return FallbackCredentialsFactory.GetCredentials();
        }

    }
}
    